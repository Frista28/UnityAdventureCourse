using _31.Scripts.Components.Weapons.Interfaces;
using _31.Scripts.Inputs.Interfaces;
using _31.Scripts.Lifecycle;
using _31.Scripts.Lifecycle.Interfaces;

namespace _31.Scripts.Components.Weapons.Controller
{
    public class WeaponControllerFactory
    {
        private readonly UpdateService _updateService;

        public WeaponControllerFactory(UpdateService updateService)
        {
            _updateService = updateService;
        }
        
        public WeaponController Create(
            IWeaponUser weaponUser,
            IDestroyable destroyable,
            IWeaponInput weaponInput)
        {
            WeaponController controller = new WeaponController(weaponUser, weaponInput);
            
            _updateService.Add(controller, destroyable);
            
            return controller;
        }
    }
}