using _22_23.Scripts.Application.Commands;
using UnityEngine;

namespace _22_23.Scripts
{
    public class InputHandler : MonoBehaviour
    {
        private MoveCommandHandler _moveCommandHandler;

        public void Initialize(MoveCommandHandler moveCommandHandler)
        {
            _moveCommandHandler = moveCommandHandler;
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
                _moveCommandHandler.Execute();
        }
    }
        
}