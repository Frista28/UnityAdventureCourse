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
            for (int i = 0; i < 3; i++)
            {
                var randomConfig = _orkConfigs[Random.Range(0, _orkConfigs.Length)];
                _enemySpawner.Spawn<Ork, OrkConfig>(randomConfig);
            }

            for (int i = 0; i < 3; i++)
            {
                var randomConfig = _elfConfigs[Random.Range(0, _elfConfigs.Length)];
                _enemySpawner.Spawn<Elf, ElfConfig>(randomConfig);
            }

            for (int i = 0; i < 3; i++)
            {
                var randomConfig = _dragonConfigs[Random.Range(0, _dragonConfigs.Length)];
                _enemySpawner.Spawn<Dragon, DragonConfig>(randomConfig);
            }
        }
    }
}