using UnityEngine;

namespace _31.Scripts.Movement.Rotator
{
    public class TransformRotator : IRotator
    {
        private readonly Transform _transform;
        private readonly float _speedRotation;
        
        private Vector3 _direction;

        public TransformRotator(Transform transform, float speedRotation)
        {
            _transform = transform;
            _speedRotation = speedRotation;
        }

        public Vector3 Direction => _direction;
        
        public void SetDirection(Vector3 direction) => _direction = direction.normalized;

        public void Rotate(float deltaTime)
        {
            if (_direction.magnitude < 0.05f)
                return;
            
            Quaternion targetRotation = Quaternion.LookRotation(_direction);
            
            float angle = _speedRotation * deltaTime;
            
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, angle);
        }
    }
}