using UnityEngine;

namespace _31.Scripts.Components
{
    public class ContactDamage : MonoBehaviour
    {
        [SerializeField] private float _damage;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out Characters.Character player))
                return;

            player.TakeDamage(_damage);
        }
    }
}