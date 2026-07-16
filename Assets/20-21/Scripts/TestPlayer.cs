using System;
using UnityEngine;

namespace _20_21.Scripts
{
    public class TestPlayer : MonoBehaviour
    {
        [SerializeField] private float _explodeRadius = 10f;
        [SerializeField] private float _explodeForce = 10f;
        
        [SerializeField] private ParticleSystem _explodeParticles;

        private DragHandler _dragHandler;
        private ExplosionCaster _explosionCaster;

        private void Awake()
        {
            _dragHandler = new DragHandler();
            _explosionCaster = new ExplosionCaster(_explodeParticles, _explodeRadius, _explodeForce);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                _dragHandler.Execute();
            
            if (Input.GetMouseButtonDown(1) && _dragHandler.IsBlocked() == false)
                _explosionCaster.Execute();
            
            _dragHandler.Process();
        }
    }
}