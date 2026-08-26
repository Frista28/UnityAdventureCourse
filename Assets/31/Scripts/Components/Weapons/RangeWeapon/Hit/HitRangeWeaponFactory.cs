using _31.Scripts.Components.Weapons.RangeWeapon.Hit.Config;
using _31.Scripts.Components.Weapons.RangeWeapon.Interfaces;

namespace _31.Scripts.Components.Weapons.RangeWeapon.Hit
{
    public class HitRangeWeaponFactory : RangeWeaponFactory<IRangeWeaponCreator<HitRangeWeaponCreationContext, HitRangeWeaponConfig>, HitRangeWeaponCreationContext, HitRangeWeaponConfig>
    {
        public HitRangeWeaponFactory(RangeWeaponCreatorRegistry<IRangeWeaponCreator<HitRangeWeaponCreationContext, HitRangeWeaponConfig>, HitRangeWeaponCreationContext, HitRangeWeaponConfig> registry) : base(registry) {}
    }
}