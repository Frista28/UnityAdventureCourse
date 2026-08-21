using _31.Scripts.Characters;
using _31.Scripts.Characters.Configs;
using _31.Scripts.Characters.Creation;
using _31.Scripts.Characters.Creation.Decorators.Controllers;
using _31.Scripts.Characters.Creation.Initializers.Controllers;
using _31.Scripts.Characters.Creation.Interfaces;
using _31.Scripts.Components.Health;
using _31.Scripts.Infrastructure.GameConditions.LoseGameConditions;
using _31.Scripts.Infrastructure.GameConditions.LoseGameConditions.Interfaces;
using _31.Scripts.Infrastructure.GameConditions.WinGameConditions;
using _31.Scripts.Infrastructure.GameConditions.WinGameConditions.Interfaces;
using _31.Scripts.Inputs;
using _31.Scripts.Inputs.Configs.Movement;
using _31.Scripts.Inputs.Creators;
using _31.Scripts.Lifecycle;
using _31.Scripts.Movement;
using _31.Scripts.Movement.Controller;
using _31.Scripts.Spawners;
using _31.Scripts.Targets;
using UnityEngine;

namespace _31.Scripts.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Character _prefabPlayerCharacter;
        [SerializeField] private CharacterConfig _playerCharacterConfig;
        [SerializeField] private MovementInputConfig _playerMovementInputConfig;
        
        [SerializeField] private Character _prefabEnemyCharacter;
        [SerializeField] private CharacterConfig _enemyCharacterConfig;
        [SerializeField] private MovementInputConfig _enemyMovementInputConfig;

        [SerializeField] private Transform[] _enemySpawnPoints;
        
        [SerializeField] private WinConditionType _winConditionType;
        [SerializeField] private LoseConditionType loseConditionType;
        
        private readonly MovementControllerUpdateService _movementControllerUpdateService = new();
        private readonly UpdateService _updateService = new();
        
        private readonly TargetProvider _targetProvider = new();
        
        private readonly MovementFactory _movementFactory = new();
        private readonly HealthFactory _healthFactory = new();
        
        private readonly DestroyableEventService _destroyableEnemyEventService = new();
        
        private TimedCharacterSpawnService<Character> _timedCharacterSpawnService;
        
        private MovementInputFactory _movementInputFactory;
        private MovementControllerFactory _movementControllerFactory;
        private CharacterFactory<Character> _characterFactory;
        
        private Character _playerCharacter;
        
        private GameMode _gameMode;

        private void Awake()
        {
            _movementControllerFactory = new MovementControllerFactory(_movementControllerUpdateService);

            RandomTargetInputCreator randomTargetInputCreator = new RandomTargetInputCreator(_targetProvider);
            _movementInputFactory =  new MovementInputFactory(randomTargetInputCreator);
            
            _characterFactory = new CharacterFactory<Character>(_movementFactory, _healthFactory, _updateService);
            
            CharacterMovementControllerInitializer<Character> characterMovementControllerInitializer = new CharacterMovementControllerInitializer<Character>(_movementInputFactory, _movementControllerFactory);

            // Собираем игрока
            ICharacterCreator<Character> playerCharacterCreator;
            playerCharacterCreator = new CharacterCreator<Character>(_characterFactory, _prefabPlayerCharacter, _playerCharacterConfig);
            playerCharacterCreator = new MovementControllerCharacterCreator<Character>(
                playerCharacterCreator, characterMovementControllerInitializer, _playerMovementInputConfig);

            _playerCharacter = playerCharacterCreator.Create(new Vector3(0, 0, 0));
            
            _targetProvider.SetTarget(_playerCharacter.transform);
            
            _playerCharacter.HealthChanged += OnPlayerHealthChanged;

            // Собираем врага
            ICharacterCreator<Character> enemyCharacterCreator;
            enemyCharacterCreator = new CharacterCreator<Character>(_characterFactory, _prefabEnemyCharacter, _enemyCharacterConfig);
            enemyCharacterCreator = new MovementControllerCharacterCreator<Character>(enemyCharacterCreator,
                characterMovementControllerInitializer, _enemyMovementInputConfig);
            enemyCharacterCreator = new TrackingCharacterCreator<Character>(enemyCharacterCreator, _destroyableEnemyEventService);
            
            CharacterSpawnerOnSpawnPoints<Character> characterSpawnerOnSpawnPoints = new CharacterSpawnerOnSpawnPoints<Character>(
                enemyCharacterCreator,
                _enemySpawnPoints);

            _timedCharacterSpawnService = new TimedCharacterSpawnService<Character>(
                characterSpawnerOnSpawnPoints,
                7f);

            WinConditionFactory winConditionFactory = new WinConditionFactory(_updateService, _destroyableEnemyEventService);

            LoseConditionFactory loseConditionFactory = new LoseConditionFactory(_playerCharacter, _destroyableEnemyEventService);
            
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
    
    public enum WinConditionType
    {
        SurviveTime,
        KillEnemies
    }

    public enum LoseConditionType
    {
        PlayerDeath,
        EnemyLimit
    }
}