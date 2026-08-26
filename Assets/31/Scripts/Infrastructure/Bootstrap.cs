using _31.Scripts.Characters;
using _31.Scripts.Characters.Configs;
using _31.Scripts.Components.Movement.Controller;
using _31.Scripts.Components.Weapons.RangeWeapon.Hit.Config;
using _31.Scripts.Infrastructure.Composition;
using _31.Scripts.Infrastructure.GameConditions.LoseGameConditions;
using _31.Scripts.Infrastructure.GameConditions.LoseGameConditions.Interfaces;
using _31.Scripts.Infrastructure.GameConditions.WinGameConditions;
using _31.Scripts.Infrastructure.GameConditions.WinGameConditions.Interfaces;
using _31.Scripts.Inputs.Configs.Movement;
using _31.Scripts.Lifecycle;
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
        private GameMode _gameMode;

        private PlayerComposition _playerComposition;
        private EnemyComposition _enemyComposition;
        private EnemySpawnerComposition _enemySpawnerComposition;
        
        private RangeWeaponUserCharacter _playerCharacter;

        private void Awake()
        {
            TargetProvider targetProvider = new();
            
            DestroyableEventService destroyableEnemyEventService = new();

            _playerComposition = new PlayerComposition(
                _prefabPlayerCharacter,
                _playerCharacterConfig,
                _playerMovementInputConfig,
                _playerHitRangeWeaponConfig,
                _updateService,
                _movementControllerUpdateService,
                targetProvider);
            
            _playerCharacter = _playerComposition.Create(Vector3.zero);
            
            targetProvider.SetTarget(_playerCharacter.transform);
            
            _playerCharacter.HealthChanged += OnPlayerHealthChanged;

            _enemyComposition = new EnemyComposition(
                _prefabEnemyCharacter,
                _enemyCharacterConfig,
                _enemyMovementInputConfig,
                _updateService,
                _movementControllerUpdateService,
                targetProvider,
                destroyableEnemyEventService);

            _enemySpawnerComposition = new EnemySpawnerComposition(
                _enemyComposition.EnemyCreator,
                _enemySpawnPoints,
                3f);
            

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
            _enemySpawnerComposition.Update(Time.deltaTime);
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
}