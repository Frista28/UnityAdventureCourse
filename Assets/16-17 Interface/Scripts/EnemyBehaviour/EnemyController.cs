using _16_17_Interface.Scripts.Interfaces;
using _16_17_Interface.Scripts.PlayerBehaviour;
using UnityEngine;

namespace _16_17_Interface.Scripts.EnemyBehaviour
{
    [RequireComponent(typeof(Collider))]
    public class EnemyController : MonoBehaviour, ITargetProvider
    {
        [SerializeField] private ParticleSystem _particlesDie;
        
        private IBehaviour _idleBehaviour;
        private IBehaviour _targetBehaviour;
        
        private bool _isTarget;
        private bool _isStayInTarget;
        
        private float _timerToTarget;
        private float _timeHoldTarget = 1f;
        
        public Transform Target { get; private set; }
        public bool HasTarget { get; private set; }
        
        public void Initialization(IBehaviour idleBehaviour, IBehaviour targetBehaviour)
        {
            _idleBehaviour = idleBehaviour;

            _isTarget = false;

            _targetBehaviour = targetBehaviour;
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
                
                SetTarget(playerController.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController))
            {
                _isStayInTarget = false;
                
                _timerToTarget = 0f;
                
                UnsetTarget();
            }
        }
        
        private void SetTarget(Transform target)
        {
            HasTarget = true;
            Target = target;
        }
        
        private void UnsetTarget()
        {
            HasTarget = false;
            Target = null;
        }
    }
}