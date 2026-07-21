using UnityEngine;

namespace _22_23.Scripts.Items.Marks
{
    public class Flag : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        
        public bool IsActive() => _meshRenderer.enabled;

        public void ChangePosition(Vector3 position)
        {
            if (transform.position != position)
            {
                transform.position = position;
                _audioSource.PlayOneShot(_audioClip);
            }
            
            if(IsActive() == false)
                _meshRenderer.enabled = true;
        }

        public void Disable()
        {
            _meshRenderer.enabled = false;
        }
    }
}