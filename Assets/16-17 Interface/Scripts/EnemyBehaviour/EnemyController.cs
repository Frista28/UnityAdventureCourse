using System;
using System.Collections.Generic;
using _16_17_Interface.Scripts.EnemyBehaviour.Enums;
using _16_17_Interface.Scripts.EnemyBehaviour.IdleBehaviour;
using _16_17_Interface.Scripts.EnemyBehaviour.TargetBehaviour;
using _16_17_Interface.Scripts.Interfaces;
using _16_17_Interface.Scripts.PlayerBehaviour;
using UnityEngine;

namespace _16_17_Interface.Scripts.EnemyBehaviour
{
    [RequireComponent(typeof(Collider))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particlesDie;
        
        private EnemyBehaviourTypes _targetBehaviourType;
        
        private IBehaviour _idleBehaviour;
        private IBehaviour _targetBehaviour;
        
        private bool _isTarget;
        private bool _isStayInTarget;
        
        private float _timerToTarget;
        private float _timeHoldTarget = 1f;
        
        public void Initialization(IBehaviour idleBehaviour, EnemyBehaviourTypes targetBehaviourType, List<Transform> wayPoints = null)
        {
            _idleBehaviour = idleBehaviour;

            _isTarget = false;

            _targetBehaviourType = targetBehaviourType;
        }

        public void Destroy()
        {
            Destroy(gameObject);
            
            Instantiate(_particlesDie, transform.position, transform.rotation);
        }

        private void Update()
        {
            if (_timerToTarget >= _timeHoldTarget)
            {
                _isTarget = false;
                _timerToTarget = 0f;
            }
            
            if (_isTarget && !_isStayInTarget)
                _timerToTarget += Time.deltaTime;
            
            if (_isTarget)
                _targetBehaviour?.Execute();
            else
                _idleBehaviour?.Execute();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController))
            {
                _isTarget = true;
                _isStayInTarget = true;
                
                switch (_targetBehaviourType)
                {
                    case EnemyBehaviourTypes.RunOut:
                        _targetBehaviour = new RunOutBehaviour(transform, playerController.transform);
                        break;
                
                    case EnemyBehaviourTypes.RunIn:
                        _targetBehaviour = new RunInBehaviour(transform, playerController.transform);
                        break;
                
                    case EnemyBehaviourTypes.Die:
                        _targetBehaviour = new DieBehaviour(this);
                        break;
                
                    default:
                        Debug.LogError("Не известный тип активного поведения");
                        return;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController))
            {
                _isStayInTarget = false;
                
                _timerToTarget = 0f;   
            }
        }
    }
}