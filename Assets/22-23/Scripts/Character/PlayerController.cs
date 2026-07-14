using System;
using UnityEngine;

namespace _22_23.Scripts.Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _healthAmount;
        
        [SerializeField]
        
        private Health _health;
        private DamageReceiver _damageReceiver;

        private void Awake()
        {
            _health = new Health(_healthAmount);
        }

        private void Start()
        {
            _damageReceiver = GetComponent<DamageReceiver>();
            _damageReceiver?.Initialize(_health);
        }
    }
}