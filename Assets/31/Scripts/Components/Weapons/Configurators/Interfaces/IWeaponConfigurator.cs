namespace _31.Scripts.Components.Weapons.Interfaces
{
    public interface IWeaponConfigurator<in TWeapon> where TWeapon : IWeapon
    {
        void Configure(TWeapon weapon);
    }
}