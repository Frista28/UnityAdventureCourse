using TMPro;
using UnityEngine;

namespace _29_30.Scripts.Timer
{
    public class TimerUI : MonoBehaviour
    {
        private const float StartSliderValue = 1f;
        
        [SerializeField] private _27_28.Scripts.Timer.SliderBar _sliderBarPrefab;
        [SerializeField] private _27_28.Scripts.Timer.LifeBar _lifeBarPrefab;
        
        [SerializeField] private TMP_InputField _inputField;
        
        private Timer _timer;
        private float _timerStartValue;
        
        private _27_28.Scripts.Timer.SliderBar _sliderBar;
        private _27_28.Scripts.Timer.LifeBar _lifeBar;

        public void Init(Timer timer)
        {
            _timer = timer;

            _timerStartValue = 10;

            CreateSliderBar();
            CreateLifeBar();
            
            _timer.CurrentTime.Changed += OnTimerUpdated;
            _timer.TimerCompleted += OnTimerCompleted;
            _timer.TimerReset += OnTimerReset;
        }

        public void OnStartButton() => _timer?.Start(_timerStartValue);

        public void OnResetButton() => _timer?.Reset();
        
        public void OnPauseButton() => _timer?.Pause();
        
        public void OnResumeButton() => _timer?.Resume();

        public void OnReadValue()
        {
            if (float.TryParse(_inputField.text, out float time))
            {
                _timerStartValue = time;
            }
            else
            {
                Debug.Log("Некорректное значение");
            }
        }

        private void OnDestroy()
        {
            _timer.CurrentTime.Changed += OnTimerUpdated;
            _timer.TimerCompleted -= OnTimerCompleted;
            _timer.TimerReset -= OnTimerReset;
        }
        
        private void CreateSliderBar()
        {
            _sliderBar = Instantiate(_sliderBarPrefab, transform);
            _sliderBar.Init(StartSliderValue);
        }

        private void CreateLifeBar()
        {
            _lifeBar = Instantiate(_lifeBarPrefab, transform);
        }
        
        private void SetStartLifeBarValue(float value) => _lifeBar.Init(Mathf.CeilToInt(value));
        
        private void SetNewLifeBarValue(float value) => _lifeBar.SetValue(Mathf.CeilToInt(value));
        
        private void OnTimerUpdated(float time)
        {
            if (!_timer.IsRunning)
                return;
            
            float sliderValue = time / _timer.StartedTime;
            _sliderBar.SetValue(sliderValue);
            
            SetNewLifeBarValue(time);
        }

        private void OnTimerCompleted()
        {
            _sliderBar.SetValue(StartSliderValue);
            SetStartLifeBarValue(0);
        }

        private void OnTimerReset()
        {
            _sliderBar.SetValue(StartSliderValue);
            SetNewLifeBarValue(0);
        }
    }
}