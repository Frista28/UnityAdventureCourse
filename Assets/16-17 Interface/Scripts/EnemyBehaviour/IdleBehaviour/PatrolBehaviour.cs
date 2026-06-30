using System.Collections.Generic;
using _16_17_Interface.Scripts.Interfaces;
using _16_17_Interface.Scripts.PlayerBehaviour;
using UnityEngine;

namespace _16_17_Interface.Scripts.EnemyBehaviour.IdleBehaviour
{
    public class PatrolBehaviour : IIdleBehaviour
    {
        private readonly Transform _self;
        
        private Queue<Vector3> _patrolQueue = new Queue<Vector3>();
        
        private Vector3 _targetPoint;
        
        private float _speed = 5f;
        private float _minDistance = 0.02f;
        
        private IMovable _movable;

        public PatrolBehaviour(Transform self, List<Transform> patrolPoints)
        {
            _self = self;
            
            foreach (Transform patrolPoint in patrolPoints)
            {
                _patrolQueue.Enqueue(patrolPoint.position);
            }

            ChangeCurrentPoint();

            _movable = new MoverLinear(self);
        }
        
        public void Execute()
        {
            RunPatrol();
        }

        private void RunPatrol()
        {
            Vector3 direction = _targetPoint - _self.position;
            
            if(direction.magnitude < _minDistance)
                ChangeCurrentPoint();
            
            _movable.Move(direction, _speed * Time.deltaTime);
        }
        
        private void ChangeCurrentPoint()
        {
            _targetPoint = _patrolQueue.Dequeue();
            _patrolQueue.Enqueue(_targetPoint);
        }
    }
}