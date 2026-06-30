using System.Collections.Generic;
using _16_17_Interface.Scripts.EnemyBehaviour.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace _16_17_Interface.Scripts.EnemyBehaviour
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyIdleBehaviourTypes _idleBehaviourType;
        [SerializeField] private EnemyTargetBehaviourTypes _targetBehaviourType;

        [SerializeField] private EnemyController _enemyPrefab;
        
        [SerializeField] private List<Transform> _wayPoints;

        private void Start()
        {
            EnemyController newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.Initialization(_idleBehaviourType, _targetBehaviourType, _wayPoints);
        }
    }
}
