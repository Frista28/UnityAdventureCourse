using UnityEngine;

namespace _31.Scripts.Controllers.Interfaces
{
    public interface ICharacterInput
    {
        Vector3 MoveDirection { get; }
        Vector3 RotateDirection { get; }
        
        void Update(float deltaTime = 0);
    }
}