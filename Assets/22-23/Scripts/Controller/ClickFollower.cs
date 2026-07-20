using System;
using _22_23.Scripts.Character;
using _22_23.Scripts.Controller.PointProviders;
using _22_23.Scripts.Controller.PointValidators;
using _22_23.Scripts.Interfaces.Click;
using _22_23.Scripts.Interfaces.Movement;
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
        private bool _isReached;
        
        private NavMeshPath _navMeshPath;
        private NavMeshQueryFilter _queryFilter;
        
        public Vector3 TargetPosition => _currentPosition;
        
        public bool IsReachedTargetPosition => _isReached;

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
            _currentPosition = _playerController.Position;
            _isReached = true;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_clickProcessor.TryProcessClick(out Vector3 point))
                {
                    SetNewTargetPosition(point);
                }
            }
            
            if (NavMeshUtils.TryGetPath(
                    _playerController.Position, 
                    _currentPosition, 
                    _queryFilter,
                    _navMeshPath))
            {
                float currentDistanceToTarget = NavMeshUtils.GetPathLength(_navMeshPath);
                
                if (EnoughCornersInPath(_navMeshPath) && !IsTargetReached(currentDistanceToTarget))
                {
                    Vector3 currentDirection = _navMeshPath.corners[1] - _navMeshPath.corners[0];
                    
                    _playerController.SetDirection(currentDirection);
                    return;
                }
            }
            
            _isReached = true;
            _playerController.SetDirection(Vector3.zero);
        }

        private bool IsTargetReached(float distanceToTarget) => distanceToTarget <= _minDistanceToTarget;
        
        private bool EnoughCornersInPath(NavMeshPath pathToTarget) => pathToTarget.corners.Length >= MinCornerCount;
        
        private void SetNewTargetPosition(Vector3 position)
        {
            _currentPosition = position;
            _isReached = false;
        }
    }
}