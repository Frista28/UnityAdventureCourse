using _16_17_Interface.Scripts.Interfaces;
using _16_17_Interface.Scripts.PlayerBehaviour;
using UnityEngine;

namespace _16_17_Interface.Scripts.EnemyBehaviour.TargetBehaviour
{
    public class RunOutBehaviour : IBehaviour
    {
        private readonly Transform _self;
        private readonly Vector3 _targetVector3;
        
        private float _speed = 6f;
        
        private IMovable _movable;

        public RunOutBehaviour(Transform self, Transform target)
        {
            _self = self;
            _targetVector3 = target.position;

            _movable = new MoverLinear(_self);
        }
        
        public void Execute()
        {
            RunOut();
        }

        private void RunOut()
        {
            Vector3 direction = _self.position - _targetVector3;
            
            _movable.Move(direction, _speed * Time.deltaTime);
        }
    }
}