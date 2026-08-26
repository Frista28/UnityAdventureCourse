using _31.Scripts.Characters;
using _31.Scripts.Characters.Configs;
using _31.Scripts.Characters.Creation;
using _31.Scripts.Characters.Creation.Components.Weapon.RangeWeapon;
using _31.Scripts.Characters.Creation.Controllers.Movement;
using _31.Scripts.Characters.Creation.Interfaces;
using _31.Scripts.Characters.Creation.Tracking;
using _31.Scripts.Components.Health;
using _31.Scripts.Components.Movement;
using _31.Scripts.Components.Movement.Controller;
using _31.Scripts.Components.Weapons.RangeWeapon.Hit;
using _31.Scripts.Components.Weapons.RangeWeapon.Hit.Config;
using _31.Scripts.Components.Weapons.RangeWeapon.Hit.Creators;
using _31.Scripts.Hits.Data.Config;
using _31.Scripts.Hits.Data.CustomData.Damage;
using _31.Scripts.Infrastructure.GameConditions.LoseGameConditions;
using _31.Scripts.Infrastructure.GameConditions.LoseGameConditions.Interfaces;
using _31.Scripts.Infrastructure.GameConditions.WinGameConditions;
using _31.Scripts.Infrastructure.GameConditions.WinGameConditions.Interfaces;
using _31.Scripts.Inputs;
using _31.Scripts.Inputs.Configs.Movement;
using _31.Scripts.Inputs.Creators;
using _31.Scripts.Interaction.Service.Hit.Damage;
using _31.Scripts.Lifecycle;
using _31.Scripts.Spawners;
using _31.Scripts.Targets;
using UnityEngine;

namespace _31.Scripts.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private RangeWeaponUserCharacter _prefabPlayerCharacter;
        [SerializeField] private CharacterConfig _playerCharacterConfig;
        [SerializeField] private MovementInputConfig _playerMovementInputConfig;
        [SerializeField] private HitRangeWeaponConfig _playerHitRangeWeaponConfig;
        
        [SerializeField] private Character _prefabEnemyCharacter;
        [SerializeField] private CharacterConfig _enemyCharacterConfig;
        [SerializeField] private MovementInputConfig _enemyMovementInputConfig;

        [SerializeField] private Transform[] _enemySpawnPoints;
        
        [SerializeField] private WinConditionType _winConditionType;
        [SerializeField] private LoseConditionType loseConditionType;
        
        private readonly MovementControllerUpdateService _movementControllerUpdateService = new();
        private readonly UpdateService _updateService = new();

        private TimedCharacterSpawnService<Character> _timedCharacterSpawnService;
        
        private RangeWeaponUserCharacter _playerCharacter;
        
        private GameMode _gameMode;

        private void Awake()
        {
            // Создание фабрик и инициализаторов для создания базового персонажа
            MovementFactory movementFactory = new();
            HealthFactory healthFactory = new();
            
            CharacterFactory<Character> characterFactory = new CharacterFactory<Character>(movementFactory, healthFactory, _updateService);
            CharacterFactory<RangeWeaponUserCharacter> shooterCharacterFactory = new CharacterFactory<RangeWeaponUserCharacter>(movementFactory, healthFactory, _updateService);
            
            // Создание фабрик и инициализаторов для подключения управления движения к персонажам
            TargetProvider targetProvider = new();
            
            RandomTargetInputCreator randomTargetInputCreator = new RandomTargetInputCreator(targetProvider);
            MovementInputFactory movementInputFactory = new MovementInputFactory(randomTargetInputCreator);
            MovementControllerFactory movementControllerFactory = new MovementControllerFactory(_movementControllerUpdateService);
            
            MovementControllerCharacterInitializer<Character> movementControllerCharacterInitializer = new MovementControllerCharacterInitializer<Character>(movementInputFactory, movementControllerFactory);
            MovementControllerCharacterInitializer<RangeWeaponUserCharacter> movementControllerShooterCharacterInitializer = new MovementControllerCharacterInitializer<RangeWeaponUserCharacter>(movementInputFactory, movementControllerFactory);
            
            // Создание фабрик и инициализатора и прочего для создания и добавления оружия к персонажу
            DamageHitDataFactory damageHitDataFactory = new DamageHitDataFactory();
            
            HitRangeWeaponBuilder<DamageHitData, DamageHitDataConfig> damageHitRangeWeaponBuilder =
                new HitRangeWeaponBuilder<DamageHitData, DamageHitDataConfig>(damageHitDataFactory);

            TeamDamageHitInteractService teamDamageHitInteractService = new TeamDamageHitInteractService();
            
            DamageHitRangeWeaponCreator damageHitRangeWeaponCreator = new DamageHitRangeWeaponCreator(damageHitRangeWeaponBuilder, teamDamageHitInteractService);
            
            HitRangeWeaponCreatorRegistry hitRangeWeaponCreatorRegistry = new HitRangeWeaponCreatorRegistry();
            hitRangeWeaponCreatorRegistry.Register(damageHitRangeWeaponCreator);
            
            HitRangeWeaponFactory hitRangeWeaponFactory = new HitRangeWeaponFactory(hitRangeWeaponCreatorRegistry);

            HitRangeWeaponCharacterInitializer<RangeWeaponUserCharacter> rangeWeaponShooterCharacterInitializer = new HitRangeWeaponCharacterInitializer<RangeWeaponUserCharacter>(hitRangeWeaponFactory);
            
            // Создание прочих зависимостей
            DestroyableEventService destroyableEnemyEventService = new();

            // Собираем игрока
            ICharacterCreator<RangeWeaponUserCharacter> playerCharacterCreator;
            playerCharacterCreator = new CharacterCreator<RangeWeaponUserCharacter>(shooterCharacterFactory, _prefabPlayerCharacter, _playerCharacterConfig);
            playerCharacterCreator = new MovementControllerCharacterCreator<RangeWeaponUserCharacter>(
                playerCharacterCreator, 
                movementControllerShooterCharacterInitializer, 
                _playerMovementInputConfig);
            playerCharacterCreator = new HitRangeWeaponCharacterCreator<RangeWeaponUserCharacter>(
                playerCharacterCreator,
                rangeWeaponShooterCharacterInitializer, 
                _playerHitRangeWeaponConfig);

            _playerCharacter = playerCharacterCreator.Create(new Vector3(0, 0, 0));
            
            targetProvider.SetTarget(_playerCharacter.transform);
            
            _playerCharacter.HealthChanged += OnPlayerHealthChanged;

            // Собираем врага
            ICharacterCreator<Character> enemyCharacterCreator;
            enemyCharacterCreator = new CharacterCreator<Character>(characterFactory, _prefabEnemyCharacter, _enemyCharacterConfig);
            enemyCharacterCreator = new MovementControllerCharacterCreator<Character>(enemyCharacterCreator,
                movementControllerCharacterInitializer, _enemyMovementInputConfig);
            enemyCharacterCreator = new TrackingCharacterCreator<Character>(enemyCharacterCreator, destroyableEnemyEventService);
            
            CharacterSpawnerOnSpawnPoints<Character> characterSpawnerOnSpawnPoints = new CharacterSpawnerOnSpawnPoints<Character>(
                enemyCharacterCreator,
                _enemySpawnPoints);

            _timedCharacterSpawnService = new TimedCharacterSpawnService<Character>(
                characterSpawnerOnSpawnPoints,
                7f);

            WinConditionFactory winConditionFactory = new WinConditionFactory(_updateService, destroyableEnemyEventService);

            LoseConditionFactory loseConditionFactory = new LoseConditionFactory(_playerCharacter, destroyableEnemyEventService);
            
            IWinCondition winCondition = winConditionFactory.Create(_winConditionType);

            ILoseCondition loseCondition = loseConditionFactory.Create(loseConditionType);

            _gameMode = new GameMode(winCondition, loseCondition);

            _gameMode.Win += OnWinCondition;
            _gameMode.Lose += OnLoseCondition;
        }

        private void Update()
        {
            _movementControllerUpdateService.Update();
            _updateService.Update(Time.deltaTime);
            _timedCharacterSpawnService.Update(Time.deltaTime);
            _gameMode.Update();
            
            if (Input.GetKeyDown(KeyCode.Space))
                _playerCharacter.UseWeapon();
        }

        private void OnDestroy()
        {
            _playerCharacter.HealthChanged -= OnPlayerHealthChanged;
            
            _gameMode.Win -= OnWinCondition;
            _gameMode.Lose -= OnLoseCondition;
            
            _gameMode.Dispose();
        }

        private void OnPlayerHealthChanged(float newValue) => Debug.Log($"Health: {newValue}");

        private void OnWinCondition() => Debug.Log("Win");
        
        private void OnLoseCondition() => Debug.Log("Lose");
    }
}