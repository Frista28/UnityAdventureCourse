using System;
using _31.Scripts.Components.Health;
using _31.Scripts.Components.Health.Interfaces;
using _31.Scripts.Lifecycle.Interfaces;
using _31.Scripts.Movement.Interfaces;
using UnityEngine;

namespace _31.Scripts.Characters
{
    public class Character : MonoBehaviour, IMovable, IRotatable, IUpdatable, IDamageable, IDestroyable
    {
        public event Action Destroyed;
        public event Action<float> HealthChanged;
        
        private Movement.Movement _movement;
        private Health _health;
        
        public void InitializeMovement(Movement.Movement movement) => _movement = movement;

        public void InitializeHealth(Health health)
        {
            _health = health;

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
        
        private void OnDied() => Destroy(gameObject);
        
        private void OnHealthChanged(float healthChanged) => HealthChanged?.Invoke(healthChanged);

        private void OnDestroy()
        {
            _health.Died -= OnDied;
            _health.HealthChanged -= OnHealthChanged;
            Destroyed?.Invoke();
        }
    }
}