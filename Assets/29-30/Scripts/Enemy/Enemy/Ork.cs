using _29_30.Scripts.Enemy.EnemyConfig;
using UnityEngine;

namespace _29_30.Scripts.Enemy.Enemy
{
    public class Ork : Enemy<OrkConfig>
    {
        private float _damage;
        
        public override void Init(OrkConfig config)
        {
            base.Init(config);
            
            _damage = config.Damage;
            
            Debug.Log($"Init ork with damage {_damage}");
        }
    }
}