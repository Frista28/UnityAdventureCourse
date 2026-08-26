using System;
using _31.Scripts.Infrastructure.GameConditions.LoseGameConditions.Interfaces;
using _31.Scripts.Infrastructure.Teams;
using _31.Scripts.Lifecycle;
using _31.Scripts.Lifecycle.Interfaces;

namespace _31.Scripts.Infrastructure.GameConditions.LoseGameConditions
{
    public class LoseConditionFactory
    {
        private readonly IDestroyable _player;
        private readonly DestroyableEventService _destroyableEnemyEventService;

        public LoseConditionFactory(IDestroyable player, DestroyableEventService destroyableEnemyEventService) 
        {
            _player = player;
            _destroyableEnemyEventService = destroyableEnemyEventService;
        }

        public ILoseCondition Create(LoseConditionType type)
        {
            return type switch
            {
                LoseConditionType.PlayerDeath => new PlayerDeathLoseCondition(_player),
                LoseConditionType.EnemyLimit => new EnemyCountLoseCondition(_destroyableEnemyEventService, 10),
                _ => throw new ArgumentException("Unknown lose condition type")
            };
        }
    }
}