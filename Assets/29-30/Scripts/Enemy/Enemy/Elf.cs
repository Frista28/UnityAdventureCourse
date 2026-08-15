using _29_30.Scripts.Enemy.EnemyConfig;
using UnityEngine;

namespace _29_30.Scripts.Enemy.Enemy
{
    public class Elf : Enemy<ElfConfig>
    {
        private float _heal;

        public override void Init(ElfConfig config)
        {
            base.Init(config);

            _heal = config.Heal;
            
            Debug.Log($"Init elf with heal {_heal}");
        }
    }
}