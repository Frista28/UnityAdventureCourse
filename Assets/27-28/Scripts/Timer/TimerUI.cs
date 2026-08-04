using UnityEngine;

namespace _27_28.Scripts.Timer
{
    public class TimerUI : MonoBehaviour
    {
        private const float StartSliderValue = 1f;
        [SerializeField] private SliderBar _sliderBarPrefab;
        
        private Timer _timer;
        
        private SliderBar _sliderBar;

        public void Init(Timer timer)
        {
            _timer = timer;

            CreateSliderBar();
            
            _timer.TimerUpdated += OnTimerUpdated;
            _timer.TimerCompleted += OnTimerCompleted;
        }

        public void OnStartButton() => _timer?.Start(10);

        public void OnResetButton() => _timer?.Reset();
        
        public void OnPauseButton() => _timer?.Pause();
        
        public void OnResumeButton() => _timer?.Resume();

        private void OnDestroy()
        {
            _timer.TimerUpdated -= OnTimerUpdated;
            _timer.TimerCompleted -= OnTimerCompleted;
        }
        
        private void CreateSliderBar()
        {
            _sliderBar = Instantiate(_sliderBarPrefab, transform);
            _sliderBar.Init(StartSliderValue);
        }
        
        private void OnTimerUpdated(float time)
        {
            float sliderValue = time / _timer.StartedTime;
            _sliderBar.SetValue(sliderValue);
        }

        private void OnTimerCompleted()
        {
            _sliderBar.SetValue(StartSliderValue);
        }
    }
}