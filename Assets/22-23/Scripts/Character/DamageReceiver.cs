using _22_23.Scripts.Interfaces.Damage;
using _22_23.Scripts.Structs;
using UnityEngine;

namespace _22_23.Scripts.Character
{
    [RequireComponent(typeof(Collider)), RequireComponent(typeof(CharacterController))]
    public class DamageReceiver : MonoBehaviour, IDamageable
    {
        private Health _health;
        private PlayerView _view;

        public void Initialize(Health health, PlayerView view)
        {
            _health = health;
            _view = view;
        }
        
        public void TakeDamage(DamageInfo damageInfo)
        {
            _health.TakeDamage(damageInfo.amount);
            
            if(_health.IsDead)
                _view.Die();
            else
                _view.Hit();
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