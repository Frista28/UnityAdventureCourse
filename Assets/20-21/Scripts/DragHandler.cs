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
    
        public bool IsBlocked() => _isDragging;

        public void Execute()
        {
            Ray ray = GetMouseRay();

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                IDraggable draggable = hit.collider.GetComponent<IDraggable>();

                if (IsStartDragging(draggable))
                {
                    Take(draggable, hit);
                }
            }
        }

        public void Process()
        {
            Drop();
        
            Drag();
        }
    
        private Ray GetMouseRay() => Camera.main.ScreenPointToRay(Input.mousePosition);

        private bool IsStartDragging(IDraggable draggable) => draggable != null && _isDragging == false && Input.GetMouseButtonDown(0);

        private void Take(IDraggable draggable, RaycastHit hit)
        {
            _draggable = draggable;
            _isDragging = true;
                    
            _draggable.StartDrag(hit.point);
                    
            _depth = Camera.main.WorldToScreenPoint(hit.point).z;
        
            _justTaken = true;
        }

        private bool IsStopDragging() => _isDragging && Input.GetMouseButtonDown(0);

        private void Drop()
        {
            if (IsStopDragging() && _justTaken == false)
            {
                _draggable.EndDrag();
            
                _isDragging = false;
                _draggable = null;
            }
        
            _justTaken = false;
        }

        private void Drag()
        {
            if (_isDragging && _draggable != null)
            {
                UpdateDepth();
            
                Vector3 mouseScreen = Input.mousePosition;
                mouseScreen.z = _depth;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        
                _draggable.UpdatePosition(worldPos);
            }
        }

        private void UpdateDepth()
        {
            _depth += Input.mouseScrollDelta.y;
        
            if (_depth < 1)
                _depth = 1;
        }
    }
}
