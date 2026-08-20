using _31.Scripts.Character;
using _31.Scripts.Components;
using _31.Scripts.Movable;
using UnityEngine;

namespace _31.Scripts.CharactersFactories
{
    public class CharacterFactory
    {
        private readonly CharacterMovementFactory _characterMovementFactory;
        private readonly CharacterUpdateService _characterUpdateService;
        
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
            
            CharacterMovement characterMovement = _characterMovementFactory.CreatePlayerCharacterMovement(characterController, instance.transform, moveSpeed, rotationSpeed);

            Shooter shooter = new Shooter();

            Health health = new Health(100, 100);
            
            instance.Initialize(characterMovement, health, shooter);
            
            _characterUpdateService.Add(instance, instance);
            
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
            
            CharacterMovement characterMovement = _characterMovementFactory.CreatePlayerCharacterMovement(characterController, instance.transform, moveSpeed, rotationSpeed);
            
            Health health = new Health(100, 100);
            
            instance.Initialize(characterMovement, health);
            
            _characterUpdateService.Add(instance, instance);
            
            return instance;
        }
    }
}