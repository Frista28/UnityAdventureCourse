using _16_17_Interface.Scripts.Interfaces;
using _16_17_Interface.Scripts.PlayerBehaviour;
using UnityEngine;

namespace _16_17_Interface.Scripts.EnemyBehaviour.TargetBehaviour
{
    public class RunInBehaviour : IBehaviour
    {
        private readonly Transform _self;
        private readonly ITargetProvider _targetProvider;
        
        private float _speed = 2f;
        
        private IMovable _movable;
        
        public RunInBehaviour(Transform self, ITargetProvider targetProvider)
        {
            _self = self;
            _targetProvider = targetProvider;

            _movable = new MoverLinear(_self);
        }
        
        public void Execute()
        {
            RunIn();
        }

        private void RunIn()
        {
            if (_targetProvider.HasTarget)
            {
                Vector3 direction = _targetProvider.Target.position - _self.position;
            
                _movable.Move(direction, _speed * Time.deltaTime);
            }
        }
    }
}