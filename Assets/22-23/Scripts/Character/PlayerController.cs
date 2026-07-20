using System;
using _22_23.Scripts.Interfaces.Movement;
using UnityEngine;

namespace _22_23.Scripts.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _healthAmount;
        
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        
        [SerializeField] private PlayerView _view;
        
        private Health _health;
        private DamageReceiver _damageReceiver;
        private CharacterController _characterController;
        
        private IMovable _movable;
        private IRotatable _rotatable;
        
        public void SetMoveDirection(Vector3 direction) => _movable.SetDirection(direction);
        
        public void SetRotateDirection(Vector3 direction) => _rotatable.SetDirection(direction);
        
        public Vector3 MoveDirection => _movable.Direction;

        private void Awake()
        {
            _health = new Health(_healthAmount);
        }

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            
            _damageReceiver = GetComponent<DamageReceiver>();
            _damageReceiver?.Initialize(_health, _view);
            
            _movable = new LinearMotion(_characterController, _moveSpeed);
            _rotatable = new DirectRotator(transform, _rotateSpeed);
        }

        private void Update()
        {
            if (_health.IsDead == false)
            {
                _movable.Move(Time.deltaTime);
                
                _rotatable.Rotate(Time.deltaTime);
            }
        }
        
        private Vector3 GetDirection() => new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
    }
}