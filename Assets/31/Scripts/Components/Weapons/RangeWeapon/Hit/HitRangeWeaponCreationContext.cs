using UnityEngine;

namespace _31.Scripts.Components.Weapons.RangeWeapon.Hit
{
    public class HitRangeWeaponCreationContext : RangeWeaponCreationContext
    {
        public GameObject Source { get; }

        public HitRangeWeaponCreationContext(Transform firePoint, GameObject source) : base(firePoint)
        {
            Source = source;
        }
    }
}