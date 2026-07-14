using UnityEngine;

namespace _22_23.Scripts.Interfaces.Movement
{
    public interface IRotatable
    {
        public Vector3 Direction { get; }
        public void Rotate();
    }
}