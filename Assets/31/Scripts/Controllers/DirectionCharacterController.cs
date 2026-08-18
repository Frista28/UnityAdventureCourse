using _31.Scripts.Character.Interfaces;
using _31.Scripts.Controllers.Interfaces;

namespace _31.Scripts.Controllers
{
    public class DirectionCharacterController
    {
        private readonly IMovable _movable;
        private readonly IRotatable _rotatable;
        private readonly ICharacterInput _characterInput;

        public DirectionCharacterController(IMovable movable, IRotatable rotatable, ICharacterInput characterInput)
        {
            _movable = movable;
            _rotatable = rotatable;
            _characterInput = characterInput;
        }

        public void Update()
        {
            _characterInput.Update();
            
            _movable.SetMoveDirection(_characterInput.MoveDirection);
            _rotatable.SetRotateDirection(_characterInput.RotateDirection);
        }
    }
}