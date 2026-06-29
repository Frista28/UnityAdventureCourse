using _16_17_Interface.Scripts.Interfaces;
using UnityEngine;

namespace _16_17_Interface.Scripts.PlayerBehaviour
{
    public class MoverLinear : IMovable
    {
        private readonly Transform _transform;

        public MoverLinear(Transform transform)
        {
            _transform = transform;
        }
        
        public void Move(Vector3 direction, float deltaDistance)
        {
            if (direction == Vector3.zero)
                return;
            
            Vector3 currentPosition = _transform.position;
            Vector3 targetPosition = _transform.position + direction.normalized;
            
            _transform.position = Vector3.MoveTowards(currentPosition, targetPosition, deltaDistance);
        }
    }
}
