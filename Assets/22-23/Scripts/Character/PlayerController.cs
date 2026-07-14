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
        
        [SerializeField] private PlayerView _view;
        
        private Health _health;
        private DamageReceiver _damageReceiver;
        private CharacterController _controller;
        
        private IMovable _movable;

        private void Awake()
        {
            _health = new Health(_healthAmount);
        }

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            
            _damageReceiver = GetComponent<DamageReceiver>();
            _damageReceiver?.Initialize(_health, _view);
            
            _movable = new LinearMotion(_controller, _moveSpeed);
        }

        private void Update()
        {
            if (_health.IsDead == false)
            {
                Vector3 direction = GetDirection();
            
                if (direction != Vector3.zero)
                    _view.Walk();
                else
                    _view.StopWalk();
            
                _movable.SetDirection(direction);
            
                _movable.Move(Time.deltaTime);
            }
        }
        
        private Vector3 GetDirection() => new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
    }
}