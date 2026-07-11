using System.Collections.Generic;
using _20_21.Scripts.Interface;
using UnityEngine;

namespace _20_21.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _explodeRadius = 10f;
        [SerializeField] private float _explodeForce = 10f;
        
        [SerializeField] private ParticleSystem _explodeParticles;
        
        private List<IAction> _actions = new List<IAction>();
        private List<IUpdateble> _updatebles = new List<IUpdateble>();
        private List<IBlockable> _blockables = new List<IBlockable>();

        public bool IsAnyBlocked()
        {
            foreach (IBlockable blockable in _blockables)
            {
                if (blockable.IsBlocked())
                    return true;
            }
            
            return false;
        }

        private void Awake()
        {
            DragHandler dragHandler = new DragHandler();
            _actions.Add(dragHandler);
            _updatebles.Add(dragHandler);
            _blockables.Add(dragHandler);

            ExplosionCaster explosionCaster = new ExplosionCaster(this, _explodeParticles, _explodeRadius, _explodeForce);
            _actions.Add(explosionCaster);
        }

        private void Update()
        {
            foreach (var action in _actions)
            {
                if (action.CanExecute())
                {
                    action.Execute();
                }
            }
            
            foreach (var updateble in _updatebles)
            {
                updateble.Process();
            }
        }
    }
}