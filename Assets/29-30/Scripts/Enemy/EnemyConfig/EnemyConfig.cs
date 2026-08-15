using System;
using UnityEngine;

namespace _29_30.Scripts.Enemy.EnemyConfig
{
    [Serializable]
    public abstract class EnemyConfig
    {
        [SerializeField] private float _health;
        
        public float Health => _health;
    }
    
    [Serializable]
    public abstract class EnemyConfig<TEnemy> : EnemyConfig where TEnemy : MonoBehaviour
    {
        [SerializeField] private TEnemy _prefab;
        
        public TEnemy Prefab => _prefab;
    }
}