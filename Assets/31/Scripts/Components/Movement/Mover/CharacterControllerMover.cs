using UnityEngine;

namespace _31.Scripts.Components.Movement.Mover
{
    public class CharacterControllerMover : IMover
    {
        private readonly CharacterController _controller;
        private readonly float _speed;
        private readonly float _gravity;
        
        private Vector3 _direction;
        private float _verticalVelocity;

        public CharacterControllerMover(CharacterController controller, float speed, float gravity)
        {
            _controller = controller;
            _speed = speed;
            _gravity = gravity;
        }
        
        public Vector3 Direction => _direction;
        
        public void SetDirection(Vector3 direction) => _direction = Vector3.ClampMagnitude(direction, 1f);
        
        public void Move(float deltaTime)
        {
            if (_controller.isGrounded && _verticalVelocity < 0)
                _verticalVelocity = -2f;

            _verticalVelocity += _gravity * deltaTime;

            Vector3 movement =
                _direction * _speed;

            movement.y = _verticalVelocity;

            _controller.Move(movement * deltaTime);
        }
    }
}
