using _31.Scripts.Components.Weapons.Interfaces;
using _31.Scripts.Inputs.Interfaces;
using _31.Scripts.Lifecycle.Interfaces;

namespace _31.Scripts.Components.Weapons.Controller
{
    public class WeaponController : IUpdatable
    {
        private readonly IWeaponUser _weaponUser;
        private readonly IWeaponInput _weaponInput;

        public WeaponController(IWeaponUser weaponUser, IWeaponInput weaponInput)
        {
            _weaponUser = weaponUser;
            _weaponInput = weaponInput;
        }
        
        public void Tick(float deltaTime)
        {
            _weaponInput.Update();
            
            if (!_weaponInput.Pressed)
                return;
            
            _weaponUser.UseWeapon();
            _weaponInput.PressedReset();
        }
    }
}