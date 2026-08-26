using UnityEngine;

namespace _31.Scripts.Inputs.Interfaces
{
    public interface IMovementInput
    {
        Vector3 MoveDirection { get; }
        Vector3 RotateDirection { get; }
        
        void Update();
    }
}