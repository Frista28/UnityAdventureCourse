using _31.Scripts.Characters;
using _31.Scripts.Characters.Configs;
using _31.Scripts.Characters.Creation;
using _31.Scripts.Characters.Creation.Controllers.Movement;
using _31.Scripts.Characters.Creation.Interfaces;
using _31.Scripts.Characters.Creation.Tracking;
using _31.Scripts.Components.Health;
using _31.Scripts.Components.Movement;
using _31.Scripts.Components.Movement.Controller;
using _31.Scripts.Inputs;
using _31.Scripts.Inputs.Configs.Movement;
using _31.Scripts.Inputs.Creators;
using _31.Scripts.Lifecycle;
using _31.Scripts.Targets;
using UnityEngine;

namespace _31.Scripts.Infrastructure.Composition
{
    public class EnemyComposition
    {
        private readonly Character _prefab;
        private readonly CharacterConfig _characterConfig;
        private readonly MovementInputConfig _movementInputConfig;

        private readonly ICharacterCreator<Character> _enemyCreator;

        public EnemyComposition(
            Character prefab,
            CharacterConfig characterConfig,
            MovementInputConfig movementInputConfig,
            UpdateService updateService,
            MovementControllerUpdateService movementControllerUpdateService,
            TargetProvider targetProvider,
            DestroyableEventService destroyableEventService)
        {
            _prefab = prefab;
            _characterConfig = characterConfig;
            _movementInputConfig = movementInputConfig;

            _enemyCreator = CreateEnemyCreator(
                updateService,
                movementControllerUpdateService,
                targetProvider,
                destroyableEventService);
        }

        public ICharacterCreator<Character> EnemyCreator => _enemyCreator;

        public Character Create(Vector3 position) => _enemyCreator.Create(position);

        private ICharacterCreator<Character> CreateEnemyCreator(
            UpdateService updateService,
            MovementControllerUpdateService movementControllerUpdateService,
            TargetProvider targetProvider,
            DestroyableEventService destroyableEventService)
        {
            MovementFactory movementFactory = new();
            HealthFactory healthFactory = new();

            CharacterFactory<Character> characterFactory =
                new CharacterFactory<Character>(
                    movementFactory,
                    healthFactory,
                    updateService);

            RandomTargetInputCreator movementInputCreator =
                new RandomTargetInputCreator(targetProvider);

            MovementInputFactory movementInputFactory =
                new MovementInputFactory(movementInputCreator);

            MovementControllerFactory movementControllerFactory =
                new MovementControllerFactory(
                    movementControllerUpdateService);

            MovementControllerCharacterInitializer<Character>
                movementInitializer =
                    new MovementControllerCharacterInitializer<Character>(
                        movementInputFactory,
                        movementControllerFactory);

            ICharacterCreator<Character> creator =
                new CharacterCreator<Character>(
                    characterFactory,
                    _prefab,
                    _characterConfig);

            creator =
                new MovementControllerCharacterCreator<Character>(
                    creator,
                    movementInitializer,
                    _movementInputConfig);

            creator =
                new TrackingCharacterCreator<Character>(
                    creator,
                    destroyableEventService);

            return creator;
        }
    }
}