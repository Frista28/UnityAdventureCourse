using _22_23.Scripts.Character.Interfaces;
using _22_23.Scripts.Interfaces.Damage;
using _22_23.Scripts.Movable;
using _22_23.Scripts.Structs;
using UnityEngine;
using UnityEngine.AI;

namespace _22_23.Scripts.Character
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody), typeof(Collider))]
    public class PlayerAgentCharacter : MonoBehaviour, IDamageable, IPositionProvider, IHealable
    {
        [SerializeField] private float _healthAmount;
        
        [SerializeField] private float _moveSpeed = 5f;  
        [SerializeField] private float _rotateSpeed = 900f;
        [SerializeField] private float _jumpSpeed = 1f;
        
        [SerializeField] private AnimationCurve _jumpCurve;
        
        [SerializeField] private PlayerView _view;
        
        private Health _health;
        private NavMeshAgent _agent;
        
        private AgentDirectionMover _mover;
        private DirectRotator _rotator;
        private AgentSinJumper _jumper;
        
        public Vector3 Position => transform.position;
        
        public Vector3 Direction => _mover.Direction;
        
        public bool IsJumping => _jumper.IsJumping();
        
        public void TakeDamage(DamageInfo damageInfo)
        {
            _health.TakeDamage(damageInfo.amount);
            
            if(_health.IsDead)
                _view.Die();
            else
                _view.Hit();
        }

        public void Heal(float amount)
        {
            _health.Heal(amount);
        }
        
        public void SetDestination(Vector3 destination) => _mover.MoveTo(destination);
        
        public void SetRotateDirection(Vector3 direction) => _rotator.SetDirection(direction);

        public NavMeshQueryFilter GetNavMeshQueryFilter()
        {
            return new NavMeshQueryFilter
            {
                areaMask = _agent.areaMask,
                agentTypeID = _agent.agentTypeID
            };
        }

        public bool IsPathComplete() => !_agent.hasPath;
        
        public bool IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData)
        {
            if (_agent.isOnOffMeshLink)
            {
                offMeshLinkData = _agent.currentOffMeshLinkData;
                return true;
            }

            offMeshLinkData = default(OffMeshLinkData);
            return false;
        }
        
        public void Jump(OffMeshLinkData offMeshLinkData) => _jumper.Jump(offMeshLinkData);
        
        private void Awake()
        {
            _health = new Health(_healthAmount);
            
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;
            _agent.speed = _moveSpeed;

            _rotator = new DirectRotator(transform, _rotateSpeed);
            _mover = new AgentDirectionMover(_agent, _moveSpeed);
            _jumper = new AgentSinJumper(_agent, _jumpSpeed, this, _jumpCurve);
        }

        private void Update()
        {
            if(IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData))
            {
                if(IsJumping == false)
                {
                    SetRotateDirection(offMeshLinkData.endPos - offMeshLinkData.startPos);
                    
                    Jump(offMeshLinkData);
                    
                    return;
                }
            }
            
            if (IsJumping == false)
                _rotator.SetDirection(Direction);
            
            _rotator.Rotate(Time.deltaTime);
        }
    }
}