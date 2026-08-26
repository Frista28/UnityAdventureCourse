using _31.Scripts.Characters.Creation.Interfaces;
using _31.Scripts.Components.Weapons.RangeWeapon.Hit.Config;
using _31.Scripts.Components.Weapons.RangeWeapon.Interfaces;
using UnityEngine;

namespace _31.Scripts.Characters.Creation.Components.Weapon.RangeWeapon
{
    public class HitRangeWeaponCharacterCreator<TCharacter> : ICharacterCreator<TCharacter> where TCharacter : Character, IRangeWeaponOwner
    {
        private readonly ICharacterCreator<TCharacter> _inner;
        private readonly HitRangeWeaponCharacterInitializer<TCharacter> _initializer;
        private readonly HitRangeWeaponConfig _hitRangeWeaponConfig;

        public HitRangeWeaponCharacterCreator(
            ICharacterCreator<TCharacter> inner,
            HitRangeWeaponCharacterInitializer<TCharacter> initializer,
            HitRangeWeaponConfig hitRangeWeaponConfig)
        {
            _inner = inner;
            _initializer = initializer;
            _hitRangeWeaponConfig = hitRangeWeaponConfig;
        }

        public TCharacter Create(Vector3 position)
        {
            TCharacter character = _inner.Create(position);

            _initializer.Initialize(character, _hitRangeWeaponConfig);

            return character;
        }
    }
}