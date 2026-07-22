using _22_23.Scripts.Character.Interfaces;
using UnityEngine;

namespace _22_23.Scripts.Items.Health
{
    [RequireComponent(typeof(Collider))]
    public class HealthPack : MonoBehaviour
    {
        [SerializeField] private float _healAmount = 20f;

        private void Awake()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IHealable healable))
            {
                healable.Heal(_healAmount);
                
                Destroy(gameObject);
            }
        }
    }
}