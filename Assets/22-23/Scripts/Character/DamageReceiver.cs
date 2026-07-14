using _22_23.Scripts.Interfaces.Damage;
using _22_23.Scripts.Structs;
using UnityEngine;

namespace _22_23.Scripts.Character
{
    [RequireComponent(typeof(Collider)), RequireComponent(typeof(Rigidbody))]
    public class DamageReceiver : MonoBehaviour, IDamageable
    {
        private Health _health;

        public void Initialize(Health health)
        {
            _health = health;
        }
        
        public void TakeDamage(DamageInfo damageInfo)
        {
            _health.TakeDamage(damageInfo.amount);
        }

        private void OnTriggerEnter(Collider other)
        {
            IDamaging damager = other.GetComponent<IDamaging>();

            if (damager != null)
            {
                damager.Activate(this);
            }
        }
    }
}