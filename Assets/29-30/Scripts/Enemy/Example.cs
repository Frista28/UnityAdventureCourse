using _29_30.Scripts.Enemy.Enemy;
using _29_30.Scripts.Enemy.EnemyConfig;
using UnityEngine;

namespace _29_30.Scripts.Enemy
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private OrkConfig[] _orkConfigs;
        [SerializeField] private ElfConfig[] _elfConfigs;
        [SerializeField] private DragonConfig[] _dragonConfigs;

        private EnemySpawner _enemySpawner;

        private void Awake()
        {
            _enemySpawner = new EnemySpawner();
        }

        private void Start()
        {
            foreach (var orkConfig in _orkConfigs)
            {
                _enemySpawner.Spawn<Ork, OrkConfig>(orkConfig);
            }
            
            foreach (var elfConfig in _elfConfigs)
            {
                _enemySpawner.Spawn<Elf, ElfConfig>(elfConfig);
            }
            
            foreach (var dragonConfig in _dragonConfigs)
            {
                _enemySpawner.Spawn<Dragon, DragonConfig>(dragonConfig);
            }
        }
    }
}