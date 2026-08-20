using System.Collections.Generic;
using _31.Scripts.Character.Interfaces;

namespace _31.Scripts.Controllers
{
    public class CharacterControllerUpdateService
    {
        private readonly List<DirectionCharacterController> _characterControllers = new();

        public void Add(DirectionCharacterController characterController, ICharacterLifecycle characterLifecycle)
        {
            _characterControllers.Add(characterController);

            characterLifecycle.Destroyed += () => Remove(characterController);
        }
        
        public void Remove(DirectionCharacterController characterController) => _characterControllers.Remove(characterController);

        public void Update()
        {
            foreach (var characterController in _characterControllers)
                characterController.Update();
        }
    }
}