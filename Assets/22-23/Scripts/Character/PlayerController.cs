using System;
using _22_23.Scripts.Character.Interfaces;
using _22_23.Scripts.Interfaces.Damage;
using _22_23.Scripts.Interfaces.Movement;
using _22_23.Scripts.Structs;
using UnityEngine;

namespace _22_23.Scripts.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour, IDamageable, IPositionProvider, IHealable
    {
        [SerializeField] private float _healthAmount;
        
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        
        [SerializeField] private PlayerView _view;
        
        private Health _health;
        private CharacterController _characterController;
        
        private LinearMotion _movable;
        private DirectRotator _rotatable;

        public void SetDirection(Vector3 direction)
        {
            _movable.SetDirection(direction);
            _rotatable.SetDirection(direction);
        }
        
        public Vector3 Position => transform.position;
        
        public Vector3 Direction => _movable.Direction;
        
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

        private void Awake()
        {
            _health = new Health(_healthAmount);
        }

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            
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
    }
}