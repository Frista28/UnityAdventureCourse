using System;
using _22_23.Scripts.Character;
using _22_23.Scripts.Controller.PointProviders;
using _22_23.Scripts.Controller.PointValidators;
using _22_23.Scripts.Interfaces.Click;
using UnityEngine;
using UnityEngine.AI;

namespace _22_23.Scripts.Controller
{
    public class ClickFollower : MonoBehaviour
    {
        [SerializeField] private GameObject _flagPrefab;
        [SerializeField] private PlayerController _playerController;
        
        private ClickProcessor _clickProcessor;
        
        private Vector3 _currentPosition;
        private GameObject _flagPrefabInstance;
        
        private NavMeshPath _navMeshPath;
        private NavMeshQueryFilter _queryFilter;

        private void Awake()
        {
            _navMeshPath = new NavMeshPath();
            
            _queryFilter = new NavMeshQueryFilter();
            _queryFilter.areaMask = NavMesh.AllAreas;
            _queryFilter.agentTypeID = 0;
            
            IPointProvider pointProvider = new CameraRaycastPointProvider(Camera.main);
            IPointValidator pointValidator = new NavMeshValidator(_queryFilter);
            _clickProcessor = new ClickProcessor(pointProvider, pointValidator);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_clickProcessor.TryProcessClick(out Vector3 point))
                {
                    Destroy(_flagPrefabInstance);
                    
                    _currentPosition = point;
                    _flagPrefabInstance = PlaceFlag(point);
                }
            }
        }
        
        private GameObject PlaceFlag(Vector3 position)
        {
            return Instantiate(_flagPrefab, position, Quaternion.identity);
        }

        private void OnDrawGizmos()
        {
            if (_navMeshPath == null)
                return;
            
            NavMesh.CalculatePath(_playerController.transform.position, _currentPosition, _queryFilter, _navMeshPath);
            
            Gizmos.color = Color.red;
            
            if (_navMeshPath.status == NavMeshPathStatus.PathComplete)
                foreach (Vector3 corner in _navMeshPath.corners)
                {
                    Gizmos.DrawSphere(corner, 0.3f);
                }
        }
    }
}