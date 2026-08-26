using _31.Scripts.Components.Weapons.RangeWeapon.Config;

namespace _31.Scripts.Components.Weapons.RangeWeapon.Interfaces
{
    public interface IRangeWeaponCreator<in TContext, in TConfig>
    where TContext : RangeWeaponCreationContext
    where TConfig : RangeWeaponConfig
    {
        IRangeWeapon Create(TContext context, TConfig config);
    }
}