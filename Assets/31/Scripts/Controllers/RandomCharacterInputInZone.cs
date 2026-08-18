using _31.Scripts.Controllers.Interfaces;
using UnityEngine;

namespace _31.Scripts.Controllers
{
    public class RandomCharacterInputInZone : ICharacterInput
    {
        private float _timer;
        private readonly float _timeToChange;
        
        private readonly Transform _target;
        private readonly Transform _self;
        private readonly float _offset;

        public RandomCharacterInputInZone(float timeToChange, Transform target, Transform self, float offset)
        {
            _timeToChange = timeToChange;
            _target = target;
            _self = self;
            _offset = offset;
            
            TimerReset();
            SetRandomDirection();
        }
        
        public Vector3 MoveDirection { get; private set; }
        public Vector3 RotateDirection => MoveDirection;

        public void Update(float deltaTime = 0)
        {
            _timer += Time.deltaTime;
            
            if (_timer < _timeToChange)
                return;
            
            SetRandomDirection();
            TimerReset();
        }

        private void SetRandomDirection()
        {
            Vector3 newDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            
            Vector3 directionToTarget = _target.position - _self.position;

            if (directionToTarget.magnitude > _offset)
            {
                directionToTarget.y = 0f;
                newDirection = directionToTarget.normalized;
            }

            MoveDirection = newDirection;
        }
        
        private void TimerReset() => _timer = 0;
    }
}