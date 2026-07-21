using _22_23.Scripts.Items.Marks;
using UnityEngine;

namespace _22_23.Scripts.Controller
{
    public class ClickView:  MonoBehaviour
    {
        [SerializeField] private Flag _flagPrefab;
        
        [SerializeField] private ClickFollower _controller;
        
        private Flag _flagPrefabInstance;

        private void Start()
        {
            _flagPrefabInstance = Instantiate(_flagPrefab, Vector3.zero, Quaternion.identity);
            _flagPrefabInstance.Disable();
        }

        public void Update()
        {
            if (_controller.IsReachedTargetPosition)
            {
                if (_flagPrefabInstance.IsActive())
                    _flagPrefabInstance.Disable();

                return;
            }

            _flagPrefabInstance.ChangePosition(_controller.TargetPosition);
        }
    }
}