using _31.Scripts.Targets.Interfaces;
using UnityEngine;

namespace _31.Scripts.Targets
{
    public class TargetProvider : ITargetProvider
    {
        private Transform _target;
        
        public Transform Target => _target;
        
        public TargetProvider() {}
        
        public TargetProvider(Transform target) => SetTarget(target);

        public void SetTarget(Transform target) => _target = target;
    }
}