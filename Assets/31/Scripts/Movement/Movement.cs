using _31.Scripts.Movement.Mover;
using _31.Scripts.Movement.Rotator;
using UnityEngine;

namespace _31.Scripts.Movement
{
    public class Movement
    {
        private readonly IMover _mover;
        private readonly IRotator _rotator;

        public Movement(IMover mover, IRotator rotator)
        {
            _mover = mover;
            _rotator = rotator;
        }
        
        public void SetMoveDirection(Vector3 moveDirection) => _mover.SetDirection(moveDirection);
        
        public void SetRotateDirection(Vector3 rotateDirection) => _rotator.SetDirection(rotateDirection);

        public void Update(float deltaTime)
        {
            _mover.Move(deltaTime);
            _rotator.Rotate(deltaTime);
        }
    }
}