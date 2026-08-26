using _31.Scripts.Components.Movement.Interfaces;
using _31.Scripts.Inputs.Interfaces;
using _31.Scripts.Lifecycle;
using _31.Scripts.Lifecycle.Interfaces;

namespace _31.Scripts.Components.Movement.Controller.Movement
{
    public class MovementControllerFactory
    {
        private readonly UpdateService _updateService;

        public MovementControllerFactory(UpdateService updateService)
        {
            _updateService = updateService;
        }
        
        public MovementController Create(
            IMovable movable,
            IRotatable rotatable,
            IDestroyable destroyable,
            IMovementInput movementInput)
        {
            MovementController controller = new MovementController(movable, rotatable, movementInput);
            
            _updateService.Add(controller, destroyable);
            
            return controller;
        }
    }
}