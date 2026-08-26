using System;
using _31.Scripts.Infrastructure.GameConditions.WinGameConditions.Interfaces;
using _31.Scripts.Lifecycle;
using UnityEngine;

namespace _31.Scripts.Infrastructure.GameConditions.WinGameConditions
{
    public class KillCountWinCondition : IWinCondition, IDisposable
    {
        private readonly DestroyableEventService _destroyableEnemyEventService;
        private readonly int _requiredKills;
        private int _kills = 0;
        
        public KillCountWinCondition(DestroyableEventService destroyableEnemyEventService, int requiredKills)
        {
            _destroyableEnemyEventService = destroyableEnemyEventService;
            
            if (requiredKills <= 0)
                throw new ArgumentOutOfRangeException(nameof(requiredKills), "Required kills must be greater than 0");
            
            _requiredKills = requiredKills;
            
            _destroyableEnemyEventService.DestroyableDestroyed += OnDestroyableDestroyed;
        }

        public bool IsCompleted => _kills >= _requiredKills;
        
        public void Dispose()
        {
            _destroyableEnemyEventService.DestroyableDestroyed -= OnDestroyableDestroyed;
        }

        private void OnDestroyableDestroyed()
        {
            _kills++;
            Debug.Log($"Enemy destroyed, kills: {_kills}/{_requiredKills}");
        }
    }
}