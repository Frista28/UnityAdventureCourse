using _16_17_Interface.Scripts.Interfaces;
using UnityEngine;

namespace _16_17_Interface.Scripts.PlayerBehaviour
{
    public class RotatorInDirection : IRotatable
    {
        private readonly Transform _transform;

        public RotatorInDirection(Transform transform)
        {
            _transform = transform;
        }
        
        public void Rotate(Vector3 direction, float deltaAngle)
        {
            if(direction == Vector3.zero)
                return;
            
            Quaternion lookRotation = Quaternion.LookRotation(direction);
        
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, deltaAngle);
        }
    }
}