using UnityEngine;

namespace _31.Scripts.Components.Movement.Rotator
{
    public interface IRotator
    {
        public Vector3 Direction { get; }

        public void SetDirection(Vector3 direction);

        public void Rotate(float deltaTime);
    }
}