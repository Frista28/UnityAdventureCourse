using _31.Scripts.Components.Weapons.RangeWeapon.Hit;
using _31.Scripts.Components.Weapons.RangeWeapon.Hit.Config;
using _31.Scripts.Components.Weapons.RangeWeapon.Interfaces;
using UnityEngine;

namespace _31.Scripts.Characters.Creation.Components.Weapon.RangeWeapon
{
    public class HitRangeWeaponCharacterInitializer<TCharacter> 
        where TCharacter : Character, IRangeWeaponOwner
    {
        private readonly HitRangeWeaponFactory _hitRangeWeaponFactory;

        public HitRangeWeaponCharacterInitializer(HitRangeWeaponFactory hitRangeWeaponFactory)
        {
            _hitRangeWeaponFactory = hitRangeWeaponFactory;
        }

        public void Initialize(TCharacter character, HitRangeWeaponConfig config)
        {
            Transform firePoint = character.GetFirePoint();

            GameObject source = character.gameObject;

            HitRangeWeaponCreationContext hitRangeWeaponCreationContext =
                new HitRangeWeaponCreationContext(firePoint, source);
            
            IRangeWeapon rangeWeapon = _hitRangeWeaponFactory.Create(hitRangeWeaponCreationContext, config);
            
            character.InitializeWeapon(rangeWeapon);
        }
    }
}