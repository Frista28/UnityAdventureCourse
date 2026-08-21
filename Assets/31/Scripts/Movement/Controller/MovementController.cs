using _31.Scripts.Inputs.Interfaces;
using _31.Scripts.Movement.Interfaces;

namespace _31.Scripts.Movement.Controller
{
    public class MovementController
    {
        private readonly IMovable _movable;
        private readonly IRotatable _rotatable;
        private readonly IMovementInput _movementInput;

        public MovementController(IMovable movable, IRotatable rotatable, IMovementInput movementInput)
        {
            _movable = movable;
            _rotatable = rotatable;
            _movementInput = movementInput;
        }

        public void Update()
        {
            _movementInput.Update();
            
            _movable.SetMoveDirection(_movementInput.MoveDirection);
            _rotatable.SetRotateDirection(_movementInput.RotateDirection);
        }
    }
}