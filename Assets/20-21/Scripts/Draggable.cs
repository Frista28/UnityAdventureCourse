using _20_21.Scripts.Interface;
using UnityEngine;

namespace _20_21.Scripts
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class Draggable : MonoBehaviour, IDraggable
    {
        private Rigidbody _rigidbody;
        
        private Vector3 _offset;
        
        public void StartDrag(Vector3 startPosition)
        {
            _rigidbody.isKinematic = true;
            
            _offset = transform.position - startPosition;
        }
        
        public void EndDrag()
        {
            _rigidbody.isKinematic = false;
        }

        public void UpdatePosition(Vector3 newPosition)
        {
            _rigidbody.MovePosition(newPosition + _offset);
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}