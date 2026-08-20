using _31.Scripts.Character;
using _31.Scripts.CharacterCreators;
using _31.Scripts.CharacterCreators.Interfaces;
using _31.Scripts.CharactersFactories;
using _31.Scripts.Controllers;
using _31.Scripts.Inputs;
using _31.Scripts.Movable;
using _31.Scripts.Spawners;
using UnityEngine;

namespace _31.Scripts.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerCharacter _prefabPlayerCharacter;
        [SerializeField] private EnemyCharacter _prefabEnemyCharacter;

        [SerializeField] private Transform[] _enemySpawnPoints;
        
        [SerializeField] private WinType _winType;
        [SerializeField] private LoseType _loseType;
        
        private CharacterControllerUpdateService _characterControllerUpdateService;
        private CharacterUpdateService _characterUpdateService;
        private EnemySpawnService _enemySpawnService;
        
        private CharacterMovementFactory _characterMovementFactory;
        private CharacterFactory _characterFactory;
        private CharacterInputControllerFactory _characterInputControllerFactory;

        private void Awake()
        {
            _characterControllerUpdateService = new CharacterControllerUpdateService();
            _characterUpdateService = new CharacterUpdateService();
            
            _characterMovementFactory = new CharacterMovementFactory();
            _characterFactory = new CharacterFactory(_characterMovementFactory, _characterUpdateService);
            _characterInputControllerFactory = new CharacterInputControllerFactory(_characterControllerUpdateService);

            PlayerCharacter playerCharacter = _characterFactory.CreatePlayer(
                _prefabPlayerCharacter,
                new Vector3(0f, 0f, 0f),
                5f,
                900f);

            playerCharacter.HealthChanged += OnPlayerHealthChanged;
            
            _characterInputControllerFactory.Create(playerCharacter, playerCharacter, playerCharacter, new KeyboardCharacterInput());
            
            EnemyFactory enemyFactory = new EnemyFactory(_characterFactory, _characterInputControllerFactory);

            IEnemyCreator aiEnemyCreator =
                new AIEnemyCreator(enemyFactory, _prefabEnemyCharacter, playerCharacter.transform, 5f, 10f);
            
            EnemySpawnerOnSpawnPoints enemySpawnerOnSpawnPoints = new EnemySpawnerOnSpawnPoints(
                aiEnemyCreator,
                _enemySpawnPoints);

            _enemySpawnService = new EnemySpawnService(
                enemySpawnerOnSpawnPoints,
                7f);
        }

        private void Update()
        {
            _characterControllerUpdateService.Update();
            _characterUpdateService.Update(Time.deltaTime);
            _enemySpawnService.Update(Time.deltaTime);
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