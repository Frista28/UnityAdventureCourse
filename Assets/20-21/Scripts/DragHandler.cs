using _20_21.Scripts.Interface;
using UnityEngine;

namespace _20_21.Scripts
{
    public class DragHandler
    {
        private IDraggable _draggable;
    
        private bool _isDragging;
        private bool _justTaken = false;
    
        private float _depth;
    
        public bool IsBlocked => _isDragging;

        public void Execute(Ray ray)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                IDraggable draggable = hit.collider.GetComponent<IDraggable>();

                if (IsStartDragging(draggable))
                {
                    Take(draggable, hit);
                }
            }
        }

        private bool IsStartDragging(IDraggable draggable) => draggable != null && _isDragging == false;

        private void Take(IDraggable draggable, RaycastHit hit)
        {
            _draggable = draggable;
            _isDragging = true;
                    
            _draggable.StartDrag(hit.point);
                    
            _depth = Camera.main.WorldToScreenPoint(hit.point).z;
        
            _justTaken = true;
        }

        public void Drop()
        {
            if (_justTaken == false && _isDragging)
            {
                _draggable.EndDrag();
            
                _isDragging = false;
                _draggable = null;
            }
        
            _justTaken = false;
        }

        public void Drag(Vector3 position, float depth)
        {
            if (_isDragging == false)
                return;
            
            UpdateDepth(depth);
            
            position.z = _depth;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(position);
        
            _draggable.UpdatePosition(worldPos);
        }

        private void UpdateDepth(float delta) => _depth = Mathf.Max(1, _depth + delta);
    }
}
