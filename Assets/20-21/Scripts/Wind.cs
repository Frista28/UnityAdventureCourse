using UnityEngine;

namespace _20_21.Scripts
{
    public class Wind : MonoBehaviour
    {
        [SerializeField] private float _speed;

        [SerializeField] private float _timeToChangeDirection;
        
        private Vector3 _direction;

        private float _timer;
        
        public Vector3 Direction => _direction;
        public float Speed => _speed;

        private void Awake()
        {
            ChangeDirection();
        }

        private void Update()
        {
            if (_timer >= _timeToChangeDirection)
            {
                ChangeDirection();
                _timer = 0;
            }
                
            _timer += Time.deltaTime;
        }

        private void ChangeDirection()
        {
            _direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        }
    }
}