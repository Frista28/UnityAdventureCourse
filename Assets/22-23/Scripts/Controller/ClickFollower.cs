using System;
using _22_23.Scripts.Character;
using _22_23.Scripts.Controller.PointProviders;
using _22_23.Scripts.Controller.PointValidators;
using _22_23.Scripts.Interfaces.Click;
using UnityEngine;

namespace _22_23.Scripts.Controller
{
    public class ClickFollower : MonoBehaviour
    {
        [SerializeField] private GameObject _flagPrefab;
        [SerializeField] private PlayerController _playerController;
        
        private ClickProcessor _clickProcessor;

        private void Awake()
        {
            IPointProvider pointProvider = new CameraRaycastPointProvider(Camera.main);
            IPointValidator pointValidator = new NavMeshValidator();
            _clickProcessor = new ClickProcessor(pointProvider, pointValidator);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_clickProcessor.TryProcessClick(out Vector3 point))
                {
                    Debug.Log($"Validating click point {point}");
                    PlaceFlag(point);
                }
            }
        }
        
        private GameObject PlaceFlag(Vector3 position)
        {
            return Instantiate(_flagPrefab, position, Quaternion.identity);
        }
    }
}