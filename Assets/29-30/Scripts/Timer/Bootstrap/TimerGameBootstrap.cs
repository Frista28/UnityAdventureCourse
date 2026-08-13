using UnityEngine;

namespace _29_30.Scripts.Timer.Bootstrap
{
    public class TimerGameBootstrap : MonoBehaviour
    {
        [SerializeField] private TimerUI _timerUI;
        
        private Timer _timer;
        
        private void Awake()
        {
            _timer = new Timer(this);
        }

        private void Start()
        {
            _timerUI.Init(_timer);
        }
    }
}