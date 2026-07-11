using UnityEngine;

namespace _20_21.Scripts.Interface
{
    public interface IDraggable
    {
        public void StartDrag(Vector3 startPosition);

        public void UpdatePosition(Vector3 dragDirection);
        
        public void EndDrag();
    }
}