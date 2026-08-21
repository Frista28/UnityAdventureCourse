using System;
using _31.Scripts.Infrastructure.GameConditions.WinGameConditions.Interfaces;
using _31.Scripts.Lifecycle.Interfaces;

namespace _31.Scripts.Infrastructure.GameConditions.WinGameConditions
{
    public class SurviveTimeWinCondition : IWinCondition, IUpdatable, IDestroyable
    {
        public event Action Destroyed;
        
        private readonly float _timeToWin;
        
        private float _timer = 0f;
        private bool _isCompleted = false;
        
        public SurviveTimeWinCondition(float timeToWin)
        {
            _timeToWin = timeToWin;
        }
        
        public bool IsCompleted => _isCompleted;

        public void Tick(float deltaTime)
        {
            if (_isCompleted)
                return;
            
            if (_timer >= _timeToWin)
            {
                _isCompleted = true;
                _timer = 0;
                Destroyed?.Invoke();
                return;
            }
            
            _timer += deltaTime;
        }
    }
}