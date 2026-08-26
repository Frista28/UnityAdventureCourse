using UnityEngine;

namespace _31.Scripts.Components.Weapons.RangeWeapon
{
    public abstract class RangeWeaponCreationContext
    {
        public Transform FirePoint { get; }

        protected RangeWeaponCreationContext(Transform firePoint)
        {
            FirePoint = firePoint;
        }
    }
} 