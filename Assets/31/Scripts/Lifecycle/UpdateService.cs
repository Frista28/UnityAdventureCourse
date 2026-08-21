using System.Collections.Generic;
using _31.Scripts.Lifecycle.Interfaces;

namespace _31.Scripts.Lifecycle
{
    public class UpdateService
    {
        private readonly List<IUpdatable> _updatables = new();

        public void Add(IUpdatable updatable, IDestroyable destroyable)
        {
            _updatables.Add(updatable);
            destroyable.Destroyed += () => _updatables.Remove(updatable);
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