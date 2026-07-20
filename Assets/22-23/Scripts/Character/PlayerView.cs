using System;
using UnityEngine;

namespace _22_23.Scripts.Character
{
    public class PlayerView : MonoBehaviour
    {
        private readonly int _hitKey = Animator.StringToHash("Hit");
        private readonly int _walkKey = Animator.StringToHash("Walk");
        private readonly int _dieKey = Animator.StringToHash("Die");
        
        [SerializeField] private PlayerController _player;
        
        private bool _canTakeDamage;
        
        private Animator _animator;

        public void Hit()
        {
            if (_canTakeDamage)
            {
                _animator.SetTrigger(_hitKey);
                
                _canTakeDamage = false;
            }
        }
        
        public void Die() => _animator.SetTrigger(_dieKey);
        
        public void OnDamageAnimationEnd()
        {
            Debug.Log("OnDamageAnimationEnd");
            _canTakeDamage = true;
        }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            
            _canTakeDamage = true;
        }

        private void Update()
        {
            Vector3 playerMoveDirection = _player.MoveDirection;
            
            if (playerMoveDirection != Vector3.zero)
                Walk();
            else
                StopWalk();
        }

        private void Walk() => _animator.SetBool(_walkKey, true);
        
        private void StopWalk() => _animator.SetBool(_walkKey, false);
    }
}