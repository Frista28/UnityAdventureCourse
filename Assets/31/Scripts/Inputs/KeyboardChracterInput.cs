using _31.Scripts.Inputs.Interfaces;
using UnityEngine;

namespace _31.Scripts.Inputs
{
    public class KeyboardMovementInput : IMovementInput
    {
        public Vector3 MoveDirection { get; private set; }
        public Vector3 RotateDirection => MoveDirection;

        public void Update()
        {
            MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }
    }
}