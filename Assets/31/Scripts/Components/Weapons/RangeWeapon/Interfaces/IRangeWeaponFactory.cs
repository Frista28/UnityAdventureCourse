using _31.Scripts.Components.Weapons.RangeWeapon.Config;

namespace _31.Scripts.Components.Weapons.RangeWeapon.Interfaces
{
    public interface IRangeWeaponFactory<in TContext, in TConfig>
        where TContext : RangeWeaponCreationContext
        where TConfig : RangeWeaponConfig
    {
        public IRangeWeapon Create(TContext context, TConfig rangeWeaponConfig);
    }
}