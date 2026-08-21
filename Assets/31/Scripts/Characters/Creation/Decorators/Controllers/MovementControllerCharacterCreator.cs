using _31.Scripts.Characters.Creation.Initializers.Controllers;
using _31.Scripts.Characters.Creation.Interfaces;
using _31.Scripts.Inputs.Configs.Movement;
using UnityEngine;

namespace _31.Scripts.Characters.Creation.Decorators.Controllers
{
    public class MovementControllerCharacterCreator<TCharacter> : ICharacterCreator<TCharacter> where TCharacter : Character
    {
        private readonly ICharacterCreator<TCharacter> _inner;
        private readonly CharacterMovementControllerInitializer<TCharacter> _initializer;
        private readonly MovementInputConfig _inputConfig;

        public MovementControllerCharacterCreator(
            ICharacterCreator<TCharacter> inner,
            CharacterMovementControllerInitializer<TCharacter> initializer,
            MovementInputConfig inputConfig)
        {
            _inner = inner;
            _initializer = initializer;
            _inputConfig = inputConfig;
        }

        public TCharacter Create(Vector3 position)
        {
            TCharacter character = _inner.Create(position);

            _initializer.Initialize(
                character,
                _inputConfig);

            return character;
        }
    }
}