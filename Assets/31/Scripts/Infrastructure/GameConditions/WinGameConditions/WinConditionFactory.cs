using System;
using _31.Scripts.Infrastructure.GameConditions.WinGameConditions.Interfaces;
using _31.Scripts.Lifecycle;
using _31.Scripts.Lifecycle.Interfaces;

namespace _31.Scripts.Infrastructure.GameConditions.WinGameConditions
{
    public class WinConditionFactory
    {
        private readonly UpdateService _updateService;
        private readonly DestroyableEventService _destroyableEnemyEventService;

        public WinConditionFactory(UpdateService updateService, DestroyableEventService destroyableEnemyEventService) 
        {
            _updateService = updateService;
            _destroyableEnemyEventService = destroyableEnemyEventService;
        }

        public IWinCondition Create(WinConditionType type)
        {
            return type switch
            {
                WinConditionType.SurviveTime => CreateAndRegister(new SurviveTimeWinCondition(10)),
                WinConditionType.KillEnemies => new KillCountWinCondition(_destroyableEnemyEventService, 10),
                _ => throw new ArgumentException("Unknown win condition type")
            };
        }

        private IWinCondition CreateAndRegister(IWinCondition condition)
        {
            if (condition is IUpdatable updatable and IDestroyable destroyable)
                _updateService.Add(updatable, destroyable);
            
            return condition;
        }
    }
}