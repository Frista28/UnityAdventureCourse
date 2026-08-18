using System.Collections.Generic;
using _31.Scripts.Character.Interfaces;

namespace _31.Scripts.Character
{
    public class CharacterUpdateService
    {
        private readonly List<IUpdatable> _updatables = new();

        public void Add(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }

        public void Update(float deltaTime)
        {
            foreach (IUpdatable updatable in _updatables)
            {
                updatable.Tick(deltaTime);
            }
        }
    }
}