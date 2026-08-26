using _31.Scripts.Characters.Configs;
using _31.Scripts.Components.Health;
using _31.Scripts.Components.Movement;
using _31.Scripts.Lifecycle;
using UnityEngine;

namespace _31.Scripts.Characters.Creation
{
    public class CharacterFactory<TCharacter> where TCharacter : Characters.Character
    {
        private readonly MovementFactory _movementFactory;
        private readonly HealthFactory _healthFactory;
        private readonly UpdateService _updateService;
        
        public CharacterFactory(MovementFactory movementFactory, HealthFactory healthFactory, UpdateService updateService)
        {
            _movementFactory = movementFactory;
            _healthFactory = healthFactory;
            _updateService = updateService;
        }
        
        public TCharacter Create(
            TCharacter prefab,
            Vector3 spawnPosition,
            CharacterConfig characterConfig) => CreateCharacter(prefab, spawnPosition, characterConfig);

        private TCharacter CreateCharacter(
            TCharacter prefab,
            Vector3 spawnPosition,
            CharacterConfig characterConfig
        )
        {
            TCharacter instance = Object.Instantiate(prefab, spawnPosition, Quaternion.identity);
            
            CreateCharacterMovement(instance, characterConfig);
            
            CreateCharacterHealth(instance, characterConfig);
            
            _updateService.Add(instance, instance);
            
            return instance;
        }

        private void CreateCharacterMovement(TCharacter instance, CharacterConfig characterConfig)
        {
            Scripts.Components.Movement.Movement movement = _movementFactory.Create(instance, characterConfig.MoverConfig, characterConfig.RotatorConfig);
            
            instance.InitializeMovement(movement);
        }

        private void CreateCharacterHealth(TCharacter instance, CharacterConfig characterConfig)
        {
            Health health = _healthFactory.Create(characterConfig.HealthConfig);
            
            instance.InitializeHealth(health);
        }
    }
}