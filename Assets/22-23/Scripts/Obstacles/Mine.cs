using _22_23.Scripts.Enums;
using _22_23.Scripts.Interfaces.Damage;
using _22_23.Scripts.Structs;
using UnityEngine;

namespace _22_23.Scripts.Obstacles
{
    [RequireComponent(typeof(Collider))]
    public class Mine : MonoBehaviour, IDamaging
    {
        [SerializeField] private float _damage;
        [SerializeField] private DamageType damageType;
        [SerializeField] private ParticleSystem _particlesPrefab;
        
        private DamageInfo _damageInfo;

        private void Awake()
        {
            _damageInfo = new DamageInfo(_damage, damageType, gameObject);
        }

        private void Start()
        {
            Collider collider = GetComponent<Collider>();
            collider.isTrigger = true;
        }

        public void Activate(IDamageable damageable)
        {
            damageable.TakeDamage(_damageInfo);
            
            Instantiate(_particlesPrefab, transform.position, Quaternion.Euler(-90, 0, 0));
            
            Destroy(gameObject);
        }
    }
}
