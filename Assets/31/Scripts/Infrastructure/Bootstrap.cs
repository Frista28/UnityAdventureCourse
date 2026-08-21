using _31.Scripts.Characters.Configs;
using _31.Scripts.Characters.Creation;
using _31.Scripts.Characters.Creation.Decorators.Controllers;
using _31.Scripts.Characters.Creation.Initializers.Controllers;
using _31.Scripts.Characters.Creation.Interfaces;
using _31.Scripts.Components.Health;
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
        [SerializeField] private Characters.Character _prefabPlayerCharacter;
        [SerializeField] private CharacterConfig _playerCharacterConfig;
        [SerializeField] private MovementInputConfig _playerMovementInputConfig;
        
        [SerializeField] private Characters.Character _prefabEnemyCharacter;
        [SerializeField] private CharacterConfig _enemyCharacterConfig;
        [SerializeField] private MovementInputConfig _enemyMovementInputConfig;

        [SerializeField] private Transform[] _enemySpawnPoints;
        
        [SerializeField] private WinType _winType;
        [SerializeField] private LoseType _loseType;
        
        private readonly MovementControllerUpdateService _movementControllerUpdateService = new();
        private readonly UpdateService _updateService = new();
        
        private readonly TargetProvider _targetProvider = new();
        
        private readonly MovementFactory _movementFactory = new();
        private readonly HealthFactory _healthFactory = new();
        
        private TimedCharacterSpawnService<Characters.Character> _timedCharacterSpawnService;
        
        private MovementInputFactory _movementInputFactory;
        private MovementControllerFactory _movementControllerFactory;
        private CharacterFactory<Characters.Character> _characterFactory;

        private void Awake()
        {
            _movementControllerFactory = new MovementControllerFactory(_movementControllerUpdateService);

            RandomTargetInputCreator randomTargetInputCreator = new RandomTargetInputCreator(_targetProvider);
            _movementInputFactory =  new MovementInputFactory(randomTargetInputCreator);
            
            _characterFactory = new CharacterFactory<Characters.Character>(_movementFactory, _healthFactory, _updateService);
            
            CharacterMovementControllerInitializer<Characters.Character> characterMovementControllerInitializer = new CharacterMovementControllerInitializer<Characters.Character>(_movementInputFactory, _movementControllerFactory);

            // Собираем игрока
            ICharacterCreator<Characters.Character> playerCharacterCreator;
            playerCharacterCreator = new CharacterCreator<Characters.Character>(_characterFactory, _prefabPlayerCharacter, _playerCharacterConfig);
            playerCharacterCreator = new MovementControllerCharacterCreator<Characters.Character>(
                playerCharacterCreator, characterMovementControllerInitializer, _playerMovementInputConfig);

            Characters.Character playerCharacter = playerCharacterCreator.Create(new Vector3(0, 0, 0));
            
            _targetProvider.SetTarget(playerCharacter.transform);
            
            playerCharacter.HealthChanged += OnPlayerHealthChanged;

            // Собираем врага
            ICharacterCreator<Characters.Character> enemyCharacterCreator;
            enemyCharacterCreator = new CharacterCreator<Characters.Character>(_characterFactory, _prefabEnemyCharacter, _enemyCharacterConfig);
            enemyCharacterCreator = new MovementControllerCharacterCreator<Characters.Character>(enemyCharacterCreator,
                characterMovementControllerInitializer, _enemyMovementInputConfig);
            
            CharacterSpawnerOnSpawnPoints<Characters.Character> characterSpawnerOnSpawnPoints = new CharacterSpawnerOnSpawnPoints<Characters.Character>(
                enemyCharacterCreator,
                _enemySpawnPoints);

            _timedCharacterSpawnService = new TimedCharacterSpawnService<Characters.Character>(
                characterSpawnerOnSpawnPoints,
                7f);
        }

        private void Update()
        {
            _movementControllerUpdateService.Update();
            _updateService.Update(Time.deltaTime);
            _timedCharacterSpawnService.Update(Time.deltaTime);
        }

        private void OnPlayerHealthChanged(float newValue) => Debug.Log($"Health: {newValue}");
    }
    
    public enum WinType
    {
        Time,
        Kill
    }

    public enum LoseType
    {
        Die,
        ManyEnemy
    }
}