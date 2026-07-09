using _16_17_Interface.Scripts.Interfaces;
using _16_17_Interface.Scripts.PlayerBehaviour;
using UnityEngine;

namespace _16_17_Interface.Scripts.EnemyBehaviour.TargetBehaviour
{
    public class RunOutBehaviour : IBehaviour
    {
        private readonly Transform _self;
        private readonly ITargetProvider _targetProvider;
        
        private float _speed = 6f;
        private Vector3 _runDirection;
        
        private bool _isRunning;
        
        private IMovable _movable;

        public RunOutBehaviour(Transform self, ITargetProvider targetProvider)
        {
            _self = self;
            _targetProvider = targetProvider;

            _movable = new MoverLinear(_self);
        }
        
        public void Execute()
        {
            RunOut();
        }

        private void RunOut()
        {
            if (_targetProvider.HasTarget)
            {
                _runDirection = _self.position - _targetProvider.Target.position;
            }
            
            _movable.Move(_runDirection, _speed * Time.deltaTime);
        }
    }
}