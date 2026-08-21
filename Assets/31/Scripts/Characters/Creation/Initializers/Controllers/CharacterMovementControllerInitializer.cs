using _31.Scripts.Inputs;
using _31.Scripts.Inputs.Configs.Movement;
using _31.Scripts.Inputs.Interfaces;
using _31.Scripts.Movement.Controller;

namespace _31.Scripts.Characters.Creation.Initializers.Controllers
{
    public class CharacterMovementControllerInitializer<TCharacter> where TCharacter : Character
    {
        private readonly MovementInputFactory _movementInputFactory;
        private readonly MovementControllerFactory _movementControllerFactory;

        public CharacterMovementControllerInitializer(
            MovementInputFactory movementInputFactory,
            MovementControllerFactory movementControllerFactory)
        {
            _movementInputFactory = movementInputFactory;
            _movementControllerFactory = movementControllerFactory;
        }

        public void Initialize(TCharacter character, MovementInputConfig config)
        {
            IMovementInput input = _movementInputFactory.Create(character.transform, config);

            _movementControllerFactory.Create(character, character, character, input);
        }
    }
}