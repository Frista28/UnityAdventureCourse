using UnityEngine;

namespace _31.Scripts.Movable.Interfaces
{
    public interface IMover
    {
        public Vector3 Direction { get; }
        
        public void SetDirection(Vector3 direction);

        public void Move(float deltaTime);
    }
}