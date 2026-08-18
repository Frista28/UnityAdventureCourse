using System;
using _31.Scripts.Character;
using _31.Scripts.Controllers;
using UnityEngine;

namespace _31.Scripts.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerCharacter _prefabPlayerCharacter;
        [SerializeField] private EnemyCharacter _prefabEnemyCharacter;
        
        private CharacterControllerUpdateService _characterControllerUpdateService;
        private CharacterUpdateService _characterUpdateService;
        
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
            
            _characterInputControllerFactory.Create(playerCharacter, playerCharacter, new KeyboardCharacterInput());
            
            EnemyCharacter enemyCharacter = _characterFactory.CreateEnemy(
                _prefabEnemyCharacter,
                new Vector3(2f, 0f, 0f),
                5f,
                900f);
            
            _characterInputControllerFactory.Create(enemyCharacter, enemyCharacter, new RandomCharacterInputInZone(5f, playerCharacter.transform, enemyCharacter.transform, 3f));
        }

        private void Update()
        {
            _characterControllerUpdateService.Update();
            _characterUpdateService.Update(Time.deltaTime);
        }
    }
}