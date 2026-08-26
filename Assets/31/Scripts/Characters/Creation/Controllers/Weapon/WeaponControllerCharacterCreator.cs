using _31.Scripts.Characters.Creation.Interfaces;
using _31.Scripts.Components.Weapons.Interfaces;
using UnityEngine;

namespace _31.Scripts.Characters.Creation.Controllers.Weapon
{
    public class WeaponControllerCharacterCreator<TCharacter> : ICharacterCreator<TCharacter> where TCharacter : Character, IWeaponUser
    {
        private readonly ICharacterCreator<TCharacter> _inner;
        private readonly WeaponControllerCharacterInitializer<TCharacter> _initializer;

        public WeaponControllerCharacterCreator(
            ICharacterCreator<TCharacter> inner,
            WeaponControllerCharacterInitializer<TCharacter> initializer)
        {
            _inner = inner;
            _initializer = initializer;
        }

        public TCharacter Create(Vector3 position)
        {
            TCharacter character = _inner.Create(position);
            
            // Костыль, не делал конфиг
            _initializer.Initialize(character);

            return character;
        }
    }
}