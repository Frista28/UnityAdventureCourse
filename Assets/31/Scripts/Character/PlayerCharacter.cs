using System;
using _31.Scripts.Character.Interfaces;
using _31.Scripts.Components;
using _31.Scripts.Movable;
using UnityEngine;

namespace _31.Scripts.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerCharacter : MonoBehaviour, IMovable, IRotatable, IUpdatable
    {
        public event Action Died;
        public event Action<float> HealthChanged;
        
        private CharacterMovement _movement;
        private Shooter _shooter;
        private Health _health;

        public void Initialize(CharacterMovement movement, Health health, Shooter shooter)
        {
            _movement = movement;
            _health = health;
            _shooter = shooter;

            _health.Died += OnDied;
            _health.HealthChanged += OnHealthChanged;
        }

        public void SetMoveDirection(Vector3 moveDirection) => _movement.SetMoveDirection(moveDirection);

        public void SetRotateDirection(Vector3 direction) => _movement.SetRotateDirection(direction);

        public void TakeDamage(float damage) => _health.TakeDamage(damage); 
        
        public void Tick(float deltaTime)
        {
            _movement.Update(deltaTime);
        }
        
        private void OnDied() => Died?.Invoke();

        private void OnHealthChanged(float currentHealth) => HealthChanged?.Invoke(currentHealth);

        private void OnDestroy()
        {
            _health.Died -= OnDied;
            _health.HealthChanged -= OnHealthChanged;
        }
    }
}