using System;
using System.Collections;
using UnityEngine;

namespace _27_28.Scripts.Timer
{
    public class Timer
    {
        public event Action<float> TimerUpdated;
        public event Action TimerCompleted;
        
        private float _timer;
        private bool _isRunning;
        
        private readonly MonoBehaviour _coroutineHandler;
        private Coroutine _coroutine;

        public Timer(MonoBehaviour coroutineHandler)
        {
            _coroutineHandler = coroutineHandler;
        }
        
        public float StartedTime { get; private set; }
        
        public float CurrentTime => _timer;
        
        public bool IsStarted => _coroutine != null;
        
        public bool IsRunning => _isRunning;

        public void Start(float time)
        {
            if (time <= 0f)
                throw new ArgumentOutOfRangeException(nameof(time), "Time must be greater than zero");
                
            if(IsStarted)
                Reset();
            
            StartedTime = time;
            SetTime(time);
            _isRunning = true;
            _coroutine = _coroutineHandler.StartCoroutine(TimerProcess());
        }
        
        public void Reset()
        {
            SetTime(0f);
            _isRunning = false;
            
            if (_coroutine != null)
            {
                _coroutineHandler.StopCoroutine(_coroutine);
                _coroutine = null;
                StartedTime = 0f;
            }
        }

        public void Pause()
        {
            if (!IsStarted)
                return;
                
            _isRunning = false;
        }

        public void Resume()
        {
            if (!IsStarted)
                return;
                
            _isRunning = true;
        }

        private void SetTime(float time)
        {
            _timer = time;
            
            if (_timer < 0f)
                _timer = 0f;
            
            TimerUpdated?.Invoke(_timer);
        }

        private IEnumerator TimerProcess()
        {
            while (_timer > 0f)
            {
                if (_isRunning)
                    SetTime(_timer - Time.deltaTime);
                
                yield return null;
            }

            _coroutine = null;
            TimerCompleted?.Invoke();
            StartedTime = 0f;
        }
    }
}
