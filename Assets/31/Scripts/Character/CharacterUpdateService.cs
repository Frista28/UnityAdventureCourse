using System.Collections.Generic;
using _31.Scripts.Character.Interfaces;

namespace _31.Scripts.Character
{
    public class CharacterUpdateService
    {
        private readonly List<IUpdatable> _updatables = new();

        public void Add(IUpdatable updatable, ICharacterLifecycle lifecycle)
        {
            _updatables.Add(updatable);
            lifecycle.Destroyed += () => _updatables.Remove(updatable);
        }

        public void Remove(IUpdatable updatable) => _updatables.Remove(updatable);

        public void Update(float deltaTime)
        {
            foreach (IUpdatable updatable in _updatables)
            {
                updatable.Tick(deltaTime);
            }
        }
    }
}