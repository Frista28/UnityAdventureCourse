using _22_23.Scripts.Interfaces.Movement;
using UnityEngine;

namespace _22_23.Scripts.Character
{
    public class DirectRotator
    {
        private Vector3 _direction;
        private float _speedRotation;
        private Transform _transform;

        public DirectRotator(Transform transform, float speedRotation)
        {
            _transform = transform;
            _speedRotation = speedRotation;
        }
        
        public Vector3 Direction => _direction;

        public void SetDirection(Vector3 direction) => _direction = direction;

        public void Rotate(float deltaTime)
        {
            if (_direction.magnitude < 0.05f)
                return;
            
            Quaternion targetRotation = Quaternion.LookRotation(_direction.normalized);
            
            float angle = _speedRotation * deltaTime;
            
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, angle);
        }
    }
}