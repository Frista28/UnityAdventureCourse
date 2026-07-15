using System;
using _22_23.Scripts.Character;
using _22_23.Scripts.Controller.PointProviders;
using _22_23.Scripts.Controller.PointValidators;
using _22_23.Scripts.Interfaces.Click;
using _22_23.Scripts.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace _22_23.Scripts.Controller
{
    public class ClickFollower : MonoBehaviour
    {
        private const int MinCornerCount = 2;
        [SerializeField] private GameObject _flagPrefab;
        [SerializeField] private PlayerController _playerController;
        
        [SerializeField] private float _minDistanceToTarget = 0.05f;
        
        private ClickProcessor _clickProcessor;
        
        private Vector3 _currentPosition;
        private GameObject _flagPrefabInstance;
        
        private NavMeshPath _navMeshPath;
        private NavMeshQueryFilter _queryFilter;

        private void Awake()
        {
            _navMeshPath = new NavMeshPath();
            
            _queryFilter = new NavMeshQueryFilter
            {
                areaMask = NavMesh.AllAreas,
                agentTypeID = 0
            };

            IPointProvider pointProvider = new CameraRaycastPointProvider(Camera.main);
            IPointValidator pointValidator = new NavMeshValidator(_queryFilter);
            _clickProcessor = new ClickProcessor(pointProvider, pointValidator);
        }

        private void Start()
        {
            _currentPosition = _playerController.transform.position;
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
            
            if (NavMeshUtils.TryGetPath(
                    _playerController.transform.position, 
                    _currentPosition, 
                    _queryFilter,
                    _navMeshPath))
            {
                float currentDistanceToTarget = NavMeshUtils.GetPathLength(_navMeshPath);
                
                if (EnoughCornersInPath(_navMeshPath) && !IsTargetReached(currentDistanceToTarget))
                {
                    Vector3 currentDirection = _navMeshPath.corners[1] - _navMeshPath.corners[0];
                    
                    _playerController.SetMoveDirection(currentDirection);
                    _playerController.SetRotateDirection(currentDirection);
                    return;
                }
            }
            
            Destroy(_flagPrefabInstance);
            _playerController.SetMoveDirection(Vector3.zero);
        }
        
        private GameObject PlaceFlag(Vector3 position) => Instantiate(_flagPrefab, position, Quaternion.identity);

        private bool IsTargetReached(float distanceToTarget) => distanceToTarget <= _minDistanceToTarget;
        
        private bool EnoughCornersInPath(NavMeshPath pathToTarget) => pathToTarget.corners.Length >= MinCornerCount;
    }
}