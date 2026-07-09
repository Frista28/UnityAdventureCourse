using System.Collections.Generic;
using _16_17_Interface.Scripts.EnemyBehaviour.Enums;
using _16_17_Interface.Scripts.EnemyBehaviour.IdleBehaviour;
using _16_17_Interface.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace _16_17_Interface.Scripts.EnemyBehaviour
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyBehaviourTypes _idleBehaviourType;
        [SerializeField] private EnemyBehaviourTypes _targetBehaviourType;

        [SerializeField] private EnemyController _enemyPrefab;
        
        [SerializeField] private List<Transform> _wayPoints;

        private void Start()
        {
            EnemyController newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            
            IBehaviour idleBehaviour;
            
            switch (_idleBehaviourType)
            {
                case EnemyBehaviourTypes.Idle:
                    idleBehaviour = new StayBehaviour();
                    break;
                
                case EnemyBehaviourTypes.TargetPointsWalk:
                    if (_wayPoints == null)
                    {
                        Debug.LogError($"Не переданы точки для патрулирования для {newEnemy.name}");
                        return;
                    }
                    
                    idleBehaviour = new PatrolBehaviour(newEnemy.transform, _wayPoints);
                    break;
                
                case EnemyBehaviourTypes.RandomWalk:
                    idleBehaviour = new RandomWalkBehaviour(newEnemy.transform);
                    break;
                
                default:
                    Debug.LogError("Не известный тип базового поведения");
                    return;
            }

            if (_wayPoints == null)
            {
                Debug.LogError("Не получилось установить поведение");
                return;
            }
            
            newEnemy.Initialization(idleBehaviour, _targetBehaviourType, _wayPoints);
        }
    }
}
