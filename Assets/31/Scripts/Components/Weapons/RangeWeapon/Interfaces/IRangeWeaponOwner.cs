using _31.Scripts.Components.Weapons.Interfaces;
using UnityEngine;

namespace _31.Scripts.Components.Weapons.RangeWeapon.Interfaces
{
    public interface IRangeWeaponOwner : IWeaponOwner
    {
        public Transform GetFirePoint();
    }
}