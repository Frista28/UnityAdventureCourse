using UnityEngine;

namespace _31.Scripts.Movable.Interfaces
{
    public interface IRotator
    {
        public Vector3 Direction { get; }

        public void SetDirection(Vector3 direction);

        public void Rotate(float deltaTime);
    }
}