using _22_23.Scripts.Application.Commands;
using _22_23.Scripts.Spawner;
using UnityEngine;

namespace _22_23.Scripts
{
    public class InputHandler : MonoBehaviour
    {
        private MoveCommandHandler _moveCommandHandler;
        private SpawnerToggleController _spawnerToggleController;

        public void Initialize(MoveCommandHandler moveCommandHandler, SpawnerToggleController spawnerToggleController)
        {
            _moveCommandHandler = moveCommandHandler;
            _spawnerToggleController = spawnerToggleController;
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
                _moveCommandHandler.Execute();
            
            if (Input.GetKeyDown(KeyCode.F))
                _spawnerToggleController.Toggle();
        }
    }
        
}