using System.Collections.Generic;
using _16_17_Interface.Scripts.Interfaces;
using _16_17_Interface.Scripts.PlayerBehaviour;
using UnityEngine;

namespace _16_17_Interface.Scripts.EnemyBehaviour.IdleBehaviour
{
    public class RandomWalkBehaviour : IBehaviour
    {
        private readonly Transform _self;
        
        private Vector3 _currentVector;
        
        private float _speed = 3f;

        private float _timeToChange = 1f;
        
        private float _timer = 0f;
        
        private IMovable _movable;

        private Vector2 _maxBorder;
        private Vector2 _minBorder;

        public RandomWalkBehaviour(Transform self)
        {
            _self = self;

            _movable = new MoverLinear(self);

            SetBorderValue();

            ChangeCurrentVector();
        }

        public void Execute()
        {
            RunWalk();
        }

        private void RunWalk()
        {
            if (_timer >= _timeToChange)
            {
                ChangeCurrentVector();
                
                _timer = 0f;
            }
            
            _timer += Time.deltaTime;
            
            _movable.Move(_currentVector, _speed  * Time.deltaTime);
        }
        
        private void ChangeCurrentVector()
        {
            float x = Random.Range(-1f, 1f);
            float z = Random.Range(-1f, 1f);
            
            if(_self.position.z <= _minBorder.y)
                z = Random.Range(0f, 1f);
            else if(_self.position.z >= _maxBorder.y)
                z = Random.Range(-1f, 0f);
            
            if(_self.position.x <= _minBorder.x)
                x = Random.Range(0f, 1f);
            else if(_self.position.x >= _maxBorder.x)
                x = Random.Range(-1f, 0f);
            
            _currentVector = new Vector3(x, 0, z).normalized;
        }

        private void SetBorderValue()
        {
            _maxBorder = new Vector2(_self.position.x + 10f, _self.position.z + 15f);
            _minBorder = new Vector2(_self.position.x - 10f, _self.position.z);
        }
    }
}