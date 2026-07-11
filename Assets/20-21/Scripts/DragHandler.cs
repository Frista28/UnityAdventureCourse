using _20_21.Scripts.Interface;
using UnityEngine;

public class DragHandler : MonoBehaviour
{
    private IDraggable _draggable;
    private bool _isDragging;
    private float _depth;
    
    private void Update()
    {
        if (_isDragging && Input.GetMouseButtonDown(0))
        {
            _draggable.EndDrag();
            
            _isDragging = false;
            _draggable = null;
            
            return;
        }
        
        Ray ray = GetMouseRay();

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            IDraggable draggable = hit.collider.GetComponent<IDraggable>();

            if (draggable != null && _isDragging == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _draggable = draggable;
                    _isDragging = true;
                    
                    _draggable.StartDrag(hit.point);
                    
                    _depth = Camera.main.WorldToScreenPoint(hit.point).z;
                }
            }
        }
        
        _depth += Input.mouseScrollDelta.y;
        
        if (_isDragging && _draggable != null)
        {
            Vector3 mouseScreen = Input.mousePosition;
            mouseScreen.z = _depth;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseScreen);
        
            _draggable.UpdatePosition(worldPos);
        }
    }

    private void OnDrawGizmos()
    {
        Ray ray = GetMouseRay();
        
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
    }
    
    private Ray GetMouseRay() => Camera.main.ScreenPointToRay(Input.mousePosition);
}
