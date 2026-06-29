using UnityEngine;

namespace _16_17_Interface.Scripts.Interfaces
{
    public interface IRotatable
    {
        public void Rotate(Vector3 direction, float deltaAngle);
    }
}