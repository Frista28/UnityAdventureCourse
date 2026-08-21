using System;
using _31.Scripts.Infrastructure.GameConditions.LoseGameConditions.Interfaces;
using _31.Scripts.Lifecycle.Interfaces;

namespace _31.Scripts.Infrastructure.GameConditions.LoseGameConditions
{
    public class PlayerDeathLoseCondition : ILoseCondition, IDisposable
    {
        private readonly IDestroyable _player;
        public PlayerDeathLoseCondition(IDestroyable player)
        {
            _player = player;
            
            _player.Destroyed += OnPlayerDestroyed;
        }
        
        public bool IsCompleted { get; private set; }
        
        private void OnPlayerDestroyed() => IsCompleted = true;

        public void Dispose()
        {
            _player.Destroyed -= OnPlayerDestroyed;
        }
    }
}