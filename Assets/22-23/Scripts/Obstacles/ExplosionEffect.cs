using UnityEngine;

namespace _22_23.Scripts.Obstacles
{
    public class ExplosionEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particlePrefab;
        [SerializeField] private AudioSource _audioSource;

        private void Start()
        {
            _particlePrefab.Play();
            _audioSource.Play();
            
            Destroy(gameObject, Mathf.Max(
                _particlePrefab.main.duration,
                _audioSource.clip.length));
        }
    }
}