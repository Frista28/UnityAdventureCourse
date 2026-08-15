using _29_30.Scripts.Enemy.EnemyConfig;
using UnityEngine;

namespace _29_30.Scripts.Enemy.Enemy
{
    public class Dragon : Enemy<DragonConfig>
    {
        private float _mana;

        public override void Init(DragonConfig config)
        {
            base.Init(config);

            _mana = config.Mana;
            
            Debug.Log($"Init dragon with mana {_mana}");
        }
    }
}