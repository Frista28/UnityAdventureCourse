using System;
using _29_30.Scripts.Enemy.Enemy;
using UnityEngine;

namespace _29_30.Scripts.Enemy.EnemyConfig
{
    [Serializable]
    public class OrkConfig : EnemyConfig<Ork>
    {
        [SerializeField] private float _damage;
        
        public float Damage => _damage;
    }
}