using System;

namespace _31.Scripts.Components
{
    public class Health
    {
        public event Action Died;
        public event Action<float> HealthChanged;
        
        private float _maxHealth;
        private float _currentHealth;
        private bool _isDead;

        public Health(float maxHealth, float currentHealth)
        {
            _maxHealth = maxHealth;
            
            if (_maxHealth < currentHealth)
                throw new ArgumentOutOfRangeException(nameof(maxHealth), "Health can't be less than max health");
            
            _currentHealth = currentHealth;
            _isDead = false;
        }
        
        public float CurrentHealth => _currentHealth;
        
        public float MaxHealth => _maxHealth;
        
        public bool IsDead => _isDead;

        public void TakeDamage(float damage)
        {
            if (_isDead) 
                return;
            
            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth);

            if (!(_currentHealth <= 0)) 
                return;
            
            _currentHealth = 0;
            _isDead = true;
            Died?.Invoke();
        }
    }
}