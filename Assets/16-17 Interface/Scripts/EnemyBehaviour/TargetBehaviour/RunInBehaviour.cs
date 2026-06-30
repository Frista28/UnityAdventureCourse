using _16_17_Interface.Scripts.Interfaces;
using _16_17_Interface.Scripts.PlayerBehaviour;
using UnityEngine;

namespace _16_17_Interface.Scripts.EnemyBehaviour.TargetBehaviour
{
    public class RunInBehaviour : ITargetBehaviour
    {
        private readonly Transform _self;
        private readonly Transform _target;
        
        private float _speed = 2f;
        
        private IMovable _movable;
        
        public RunInBehaviour(Transform self, Transform target)
        {
            _self = self;
            _target = target;

            _movable = new MoverLinear(_self);
        }
        
        public void Execute()
        {
            RunIn();
        }

        private void RunIn()
        {
            Vector3 direction = _target.position - _self.position;
            
            _movable.Move(direction, _speed * Time.deltaTime);
        }
    }
}