using System.Collections.Generic;
using _31.Scripts.Lifecycle.Interfaces;

namespace _31.Scripts.Components.Movement.Controller
{
    public class MovementControllerUpdateService
    {
        private readonly List<MovementController> _movementControllers = new();

        public void Add(MovementController controller, IDestroyable destroyable)
        {
            _movementControllers.Add(controller);

            destroyable.Destroyed += () => Remove(controller);
        }

        private void Remove(MovementController controller) => _movementControllers.Remove(controller);

        public void Update()
        {
            foreach (var movementController in _movementControllers)
                movementController.Update();
        }
    }
}