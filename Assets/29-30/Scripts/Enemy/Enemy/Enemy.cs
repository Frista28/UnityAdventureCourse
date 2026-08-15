using UnityEngine;

namespace _29_30.Scripts.Enemy.Enemy
{
    public abstract class Enemy<TConfig> : MonoBehaviour where TConfig : EnemyConfig.EnemyConfig
    {
        private float _health;
        
        public virtual void Init(TConfig config)
        {
            _health = config.Health;
        }
    }
}