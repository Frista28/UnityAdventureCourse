using UnityEngine;

namespace _16_17_Interface.Scripts.Interfaces
{
    public interface IMovable
    {
        public void Move(Vector3 direction, float deltaDistance);
    }
}