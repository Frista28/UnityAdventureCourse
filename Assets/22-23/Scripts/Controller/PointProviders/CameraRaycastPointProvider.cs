using _22_23.Scripts.Interfaces.Click;
using UnityEngine;

namespace _22_23.Scripts.Controller.PointProviders
{
    public class CameraRaycastPointProvider : IPointProvider
    {
        private readonly Camera _camera;
        private readonly float _distance;

        public CameraRaycastPointProvider(Camera camera, float distance = 10f)
        {
            _camera = camera;
            _distance = distance;
        }
        
        public bool TryGetHit(out RaycastHit point)
        {
            point = default;
            
            Ray ray = GetMouseRay();

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                point = hit;
                return true;
            }
            
            return false;
        }
        
        private Ray GetMouseRay() => _camera.ScreenPointToRay(Input.mousePosition);
    }
}