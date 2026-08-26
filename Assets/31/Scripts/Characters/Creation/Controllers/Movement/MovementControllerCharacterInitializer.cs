using _31.Scripts.Components.Movement.Controller;
using _31.Scripts.Components.Movement.Controller.Movement;
using _31.Scripts.Inputs;
using _31.Scripts.Inputs.Configs.Movement;
using _31.Scripts.Inputs.Interfaces;

namespace _31.Scripts.Characters.Creation.Controllers.Movement
{
    public class MovementControllerCharacterInitializer<TCharacter> where TCharacter : Character
    {
        private readonly MovementInputFactory _movementInputFactory;
        private readonly MovementControllerFactory _movementControllerFactory;

        public MovementControllerCharacterInitializer(
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