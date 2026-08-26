using _31.Scripts.Infrastructure.GameConditions.LoseGameConditions.Interfaces;
using _31.Scripts.Lifecycle;

namespace _31.Scripts.Infrastructure.GameConditions.LoseGameConditions
{
    public class EnemyCountLoseCondition : ILoseCondition
    {
        private readonly DestroyableEventService _destroyableEnemyEventService;

        private readonly int _enemyCountToLose;

        public EnemyCountLoseCondition(DestroyableEventService destroyableEnemyEventService, int enemyCountToLose)
        {
            _destroyableEnemyEventService = destroyableEnemyEventService;
            _enemyCountToLose = enemyCountToLose;
        }

        public bool IsCompleted => _destroyableEnemyEventService.Count >= _enemyCountToLose;
    }
}