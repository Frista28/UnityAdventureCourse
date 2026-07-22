using UnityEngine;

namespace _22_23.Scripts.Character
{
    public class Health
    {
        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; private set; }
        
        public bool IsDead => CurrentHealth <= 0;
        
        public Health(float maxHealth)
        {
            CurrentHealth = maxHealth;
            MaxHealth = maxHealth;
        }
        
        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            
            if (CurrentHealth <= 0)
                CurrentHealth = 0;

            DebugHP();
        }

        public void Heal(float healAmount)
        {
            CurrentHealth += healAmount;
            
            if (CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;

            DebugHP();
        }

        private void DebugHP()
        {
            Debug.Log(CurrentHealth);
        }
    }
}