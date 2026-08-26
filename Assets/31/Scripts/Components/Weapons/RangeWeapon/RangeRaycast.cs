using System;
using _31.Scripts.Components.Weapons.RangeWeapon.Config;
using _31.Scripts.Components.Weapons.RangeWeapon.Interfaces;
using UnityEngine;

namespace _31.Scripts.Components.Weapons.RangeWeapon
{
    public abstract class RangeRaycast : IRangeWeapon
    {
        private readonly float _range;
        
        private readonly Transform _firePoint;

        protected RangeRaycast(Transform firePoint, RangeRaycastConfig rangeRaycastConfig)
        {
            _firePoint = firePoint ?? throw new ArgumentNullException(nameof(firePoint));
            _range = rangeRaycastConfig.Range;
        }
        
        public void Use()
        {
            if (!Physics.Raycast(
                    _firePoint.position,
                    _firePoint.forward,
                    out RaycastHit hit,
                    _range))
                return;

            OnRaycastHit(hit);
        }
        
        protected abstract void OnRaycastHit(RaycastHit hit);
    }
}