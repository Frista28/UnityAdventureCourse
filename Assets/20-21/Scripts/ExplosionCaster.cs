using _20_21.Scripts.Interface;
using UnityEngine;

namespace _20_21.Scripts
{
    public class ExplosionCaster
    {
        private float _radius;
        private float _force;
        
        private ParticleSystem _explodeParticles;

        public ExplosionCaster(ParticleSystem particleSystem, float radius = 10f, float force = 10f)
        {
            _radius = radius;
            _force = force;
            _explodeParticles = particleSystem;
        }

        public void Execute(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 explosionPoint = hit.point;
                
                Object.Instantiate(_explodeParticles, hit.point, Quaternion.Euler(new Vector3(-90, 0, 0)));
                
                Collider[] colliders = Physics.OverlapSphere(explosionPoint, _radius);

                foreach (Collider collider in colliders)
                {
                    Rigidbody rb = collider.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        Vector3 direction = rb.position - explosionPoint;
                        
                        rb.AddForce(direction.normalized * _force, ForceMode.Impulse);
                    }
                }
                
            }
        }
    }
}