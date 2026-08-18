using _31.Scripts.Components;
using _31.Scripts.Movable;
using UnityEngine;

namespace _31.Scripts.Character
{
    public class CharacterFactory
    {
        private CharacterMovementFactory _characterMovementFactory;
        private CharacterUpdateService _characterUpdateService;
        
        public CharacterFactory(CharacterMovementFactory characterMovementFactory, CharacterUpdateService characterUpdateService)
        {
            _characterMovementFactory = characterMovementFactory;
            _characterUpdateService = characterUpdateService;
        }

        public PlayerCharacter CreatePlayer(
            PlayerCharacter prefab,
            Vector3 spawnPosition,
            float moveSpeed,
            float rotationSpeed)
        {
            PlayerCharacter instance = Object.Instantiate(prefab, spawnPosition, Quaternion.identity);
            
            CharacterController characterController = instance.GetComponent<CharacterController>();
            
            CharacterMovement characterMovement = _characterMovementFactory.CreatePlayerCharacterMovement(characterController, instance.transform, spawnPosition, moveSpeed, rotationSpeed);

            Shooter shooter = new Shooter();

            Health health = new Health(100, 100);
            
            instance.Initialize(characterMovement, health, shooter);
            
            _characterUpdateService.Add(instance);
            
            return instance;
        }

        public EnemyCharacter CreateEnemy(
            EnemyCharacter prefab,
            Vector3 spawnPosition,
            float moveSpeed,
            float rotationSpeed)
        {
            EnemyCharacter instance = Object.Instantiate(prefab, spawnPosition, Quaternion.identity);
            
            CharacterController characterController = instance.GetComponent<CharacterController>();
            
            CharacterMovement characterMovement = _characterMovementFactory.CreatePlayerCharacterMovement(characterController, instance.transform, spawnPosition, moveSpeed, rotationSpeed);
            
            Health health = new Health(100, 100);
            
            instance.Initialize(characterMovement, health);
            
            _characterUpdateService.Add(instance);
            
            return instance;
        }
    }
}