using UnityEngine;

namespace _22_23.Scripts.Controller
{
    public class ClickView:  MonoBehaviour
    {
        [SerializeField] private GameObject _flagPrefab;
        
        [SerializeField] private ClickFollower _controller;
        
        private GameObject _flagPrefabInstance;

        private void Start()
        {
            _flagPrefabInstance = Instantiate(_flagPrefab, Vector3.zero, Quaternion.identity);
            _flagPrefabInstance.SetActive(false);
        }

        public void Update()
        {
            if (_controller.IsReachedTargetPosition)
            {
                if (_flagPrefabInstance.activeSelf)
                    DisableFlag();

                return;
            }

            _flagPrefabInstance.transform.position = _controller.TargetPosition;

            if (_flagPrefabInstance.activeSelf == false)
                EnableFlag();
        }
        
        private void DisableFlag() => _flagPrefabInstance.SetActive(false);
        
        private void EnableFlag() => _flagPrefabInstance.SetActive(true);
    }
}