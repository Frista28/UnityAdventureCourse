using _31.Scripts.Components.Teams;
using _31.Scripts.Components.Weapons.Interfaces;
using _31.Scripts.Components.Weapons.RangeWeapon.Interfaces;
using UnityEngine;

namespace _31.Scripts.Characters
{
    [RequireComponent(typeof(TeamMember))]
    public class RangeWeaponUserCharacter : Character, IRangeWeaponOwner, IWeaponUser
    {
        [SerializeField] private Transform _firePoint;
        
        private IWeapon _weapon;

        public Transform GetFirePoint() => _firePoint;

        public void InitializeWeapon(IWeapon weapon) => _weapon = weapon;

        public void UseWeapon() => _weapon.Use();
    }
}