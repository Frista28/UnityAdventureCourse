using _22_23.Scripts.Interfaces.Movement;
using UnityEngine;

namespace _22_23.Scripts.Character
{
    public class LinearMotion
    {
        private Vector3 _direction;
        private readonly CharacterController _controller;
        
        private readonly float _speed;

        public LinearMotion(CharacterController controller, float speed)
        {
            _controller = controller;
            _speed = speed;
        }
        
        public Vector3 Direction => _direction;
        
        public void SetDirection(Vector3 direction) => _direction = direction.normalized;
        
        public void Move(float deltaTime)
        {
            Vector3 currentDirection = _direction * (_speed * deltaTime);
            _controller.Move(currentDirection);
        }
    }
}