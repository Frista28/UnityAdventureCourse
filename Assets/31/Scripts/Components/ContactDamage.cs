using _31.Scripts.Character;
using UnityEngine;

namespace _31.Scripts.Components
{
    public class ContactDamage : MonoBehaviour
    {
        [SerializeField] private float _damage;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerCharacter player))
                return;

            player.TakeDamage(_damage);
        }
    }
}