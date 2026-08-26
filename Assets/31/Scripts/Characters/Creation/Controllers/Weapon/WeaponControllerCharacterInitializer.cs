using _31.Scripts.Components.Weapons.Controller;
using _31.Scripts.Components.Weapons.Interfaces;
using _31.Scripts.Inputs;
using _31.Scripts.Inputs.Interfaces;

namespace _31.Scripts.Characters.Creation.Controllers.Weapon
{
    public class WeaponControllerCharacterInitializer<TCharacter> where TCharacter : Character, IWeaponUser
    {
        private readonly WeaponControllerFactory _weaponControllerFactory;

        public WeaponControllerCharacterInitializer(WeaponControllerFactory weaponControllerFactory)
        {
            _weaponControllerFactory = weaponControllerFactory;
        }

        public void Initialize(TCharacter character)
        {
            // Костыль, добавить фабрику
            IWeaponInput input = new WeaponUseInput();

            _weaponControllerFactory.Create(character, character, input);
        }
    }
}