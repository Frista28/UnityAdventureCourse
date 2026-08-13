using System;
using System.Collections;
using _29_30.Scripts.Timer.ReactiveUtils;
using UnityEngine;

namespace _29_30.Scripts.Timer
{
    public class Timer
    {
        public event Action TimerCompleted;
        public event Action TimerReset;

        private bool _isRunning;
        
        private readonly MonoBehaviour _coroutineHandler;
        private Coroutine _coroutine;

        public Timer(MonoBehaviour coroutineHandler)
        {
            _coroutineHandler = coroutineHandler;
            CurrentTime = new ReactiveVariable<float>();
        }
        
        public float StartedTime { get; private set; }
        
        public ReactiveVariable<float> CurrentTime { get; private set; }

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
            CurrentTime.Value = 0f;
            _isRunning = false;
            
            if (_coroutine != null)
            {
                _coroutineHandler.StopCoroutine(_coroutine);
                _coroutine = null;
                StartedTime = 0f;
            }
            
            TimerReset?.Invoke();
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
            if (time < 0f)
                CurrentTime.Value = 0f;
            else
                CurrentTime.Value = time;
        }

        private IEnumerator TimerProcess()
        {
            while (CurrentTime.Value > 0f)
            {
                if (_isRunning)
                    SetTime(CurrentTime.Value - Time.deltaTime);
                
                yield return null;
            }

            _coroutine = null;
            _isRunning = false;
            TimerCompleted?.Invoke();
            StartedTime = 0f;
        }
    }
}
