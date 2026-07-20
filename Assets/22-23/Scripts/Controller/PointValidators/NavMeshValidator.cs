using _22_23.Scripts.Interfaces.Click;
using UnityEngine;
using UnityEngine.AI;

namespace _22_23.Scripts.Controller.PointValidators
{
    public class NavMeshValidator : IPointValidator
    {
        private readonly float _maxDistance;
        private readonly NavMeshQueryFilter _queryFilter;
        
        public NavMeshValidator(NavMeshQueryFilter queryFilter, float maxDistance = 0.1f)
        {
            _queryFilter = queryFilter;
            _maxDistance = Mathf.Max(0.1f, maxDistance);
        }
        
        public bool IsValid(RaycastHit hit)
        {
            return NavMesh.SamplePosition(hit.point, out _, _maxDistance, _queryFilter);
        }
    }
}