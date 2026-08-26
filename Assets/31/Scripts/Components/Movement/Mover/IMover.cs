using UnityEngine;

namespace _31.Scripts.Components.Movement.Mover
{
    public interface IMover
    {
        public Vector3 Direction { get; }
        
        public void SetDirection(Vector3 direction);

        public void Move(float deltaTime);
    }
}