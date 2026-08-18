using System.Collections.Generic;

namespace _31.Scripts.Controllers
{
    public class CharacterControllerUpdateService
    {
        private readonly List<DirectionCharacterController> _characterControllers = new();

        public void Add(DirectionCharacterController characterController)
        {
            _characterControllers.Add(characterController);
        }

        public void Update()
        {
            foreach (var characterController in _characterControllers)
                characterController.Update();
        }
    }
}