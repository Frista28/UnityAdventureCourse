using UnityEngine;

namespace _22_23.Scripts.Interfaces.Movement
{
    public interface IMovable
    {
        public Vector3 Direction { get; }
        public void SetDirection(Vector3 direction);
        public void Move(float deltaTime);
    }
}