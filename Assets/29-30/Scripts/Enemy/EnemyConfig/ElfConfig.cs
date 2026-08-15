using System;
using _29_30.Scripts.Enemy.Enemy;
using UnityEngine;

namespace _29_30.Scripts.Enemy.EnemyConfig
{
    [Serializable]
    public class ElfConfig : EnemyConfig<Elf>
    {
        [SerializeField] private float _heal;
        
        public float Heal => _heal;
    }
}