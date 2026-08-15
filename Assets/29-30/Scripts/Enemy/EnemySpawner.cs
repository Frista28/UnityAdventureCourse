using _29_30.Scripts.Enemy.Enemy;
using UnityEngine;

namespace _29_30.Scripts.Enemy
{
    public class EnemySpawner
    {
        public TEnemy Spawn<TEnemy, TConfig>(TConfig config) 
            where TEnemy : Enemy<TConfig> 
            where TConfig : EnemyConfig.EnemyConfig<TEnemy>
        {
            TEnemy instance = Object.Instantiate(config.Prefab);
            
            instance.Init(config);
            
            return instance;
        }
    }
}