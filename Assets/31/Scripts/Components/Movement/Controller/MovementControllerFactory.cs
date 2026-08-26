using _31.Scripts.Components.Movement.Interfaces;
using _31.Scripts.Inputs.Interfaces;
using _31.Scripts.Lifecycle.Interfaces;

namespace _31.Scripts.Components.Movement.Controller
{
    public class MovementControllerFactory
    {
        private readonly MovementControllerUpdateService _movementControllerUpdateService;

        public MovementControllerFactory(MovementControllerUpdateService movementControllerUpdateService)
        {
            _movementControllerUpdateService = movementControllerUpdateService;
        }
        
        public MovementController Create(
            IMovable movable,
            IRotatable rotatable,
            IDestroyable destroyable,
            IMovementInput movementInput)
        {
            MovementController controller = new MovementController(movable, rotatable, movementInput);
            
            _movementControllerUpdateService.Add(controller, destroyable);
            
            return controller;
        }
    }
}