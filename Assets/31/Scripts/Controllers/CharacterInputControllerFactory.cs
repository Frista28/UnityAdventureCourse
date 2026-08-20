using _31.Scripts.Character.Interfaces;
using _31.Scripts.Inputs.Interfaces;

namespace _31.Scripts.Controllers
{
    public class CharacterInputControllerFactory
    {
        private readonly CharacterControllerUpdateService _characterControllerUpdateService;

        public CharacterInputControllerFactory(CharacterControllerUpdateService characterControllerUpdateService)
        {
            _characterControllerUpdateService = characterControllerUpdateService;
        }
        
        public DirectionCharacterController Create(
            IMovable movable,
            IRotatable rotatable,
            ICharacterLifecycle lifecycle,
            ICharacterInput characterInput)
        {
            DirectionCharacterController controller = new DirectionCharacterController(movable, rotatable, characterInput);
            
            _characterControllerUpdateService.Add(controller, lifecycle);
            
            return controller;
        }
    }
}