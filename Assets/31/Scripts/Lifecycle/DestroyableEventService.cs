using System;
using System.Collections.Generic;
using _31.Scripts.Lifecycle.Interfaces;

namespace _31.Scripts.Lifecycle
{
    public class DestroyableEventService
    {
        public event Action DestroyableDestroyed;

        private List<IDestroyable> _destroyables = new();
        
        public int Count => _destroyables.Count;

        public void AddDestroyable(IDestroyable destroyable)
        {
            _destroyables.Add(destroyable);
            destroyable.Destroyed += () => Remove(destroyable);
        }

        private void Remove(IDestroyable destroyable)
        {
            _destroyables.Remove(destroyable);
            DestroyableDestroyed?.Invoke();
        }
    }
}