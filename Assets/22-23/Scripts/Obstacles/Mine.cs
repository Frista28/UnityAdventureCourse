using System.Collections;
using _22_23.Scripts.Enums;
using _22_23.Scripts.Interfaces.Damage;
using _22_23.Scripts.Structs;
using UnityEngine;

namespace _22_23.Scripts.Obstacles
{
    [RequireComponent(typeof(SphereCollider))]
    public class Mine : MonoBehaviour
    {
        [SerializeField] private float _damage = 10f;
        [SerializeField] private float _radius = 1f;
        [SerializeField] private float _timeToExplode = 1f;
        
        [SerializeField] private DamageType damageType;
        
        [SerializeField] private MineView _view;
        
        private DamageInfo _damageInfo;
        
        private float _time;
        
        private bool _isActive;

        private void Awake()
        {
            _damageInfo = new DamageInfo(_damage, damageType, gameObject);
            _isActive = false;
            
            SphereCollider collider = GetComponent<SphereCollider>();
            collider.isTrigger = true;
            collider.radius = _radius;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable _))
                Activate();
        }

        private void Activate()
        {
            if (_isActive)
                return;
            
            _isActive = true;
            StartCoroutine(ExplodeTimer());
        }
        
        private void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
            
            foreach (Collider col in colliders)
            {
                if (col.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(_damageInfo);
                }
            }
            
            _view.Explode();
            
            Destroy(gameObject);
        }
        
        private IEnumerator ExplodeTimer()
        {
            yield return new WaitForSeconds(_timeToExplode);
            Explode();
        }
    }
}
