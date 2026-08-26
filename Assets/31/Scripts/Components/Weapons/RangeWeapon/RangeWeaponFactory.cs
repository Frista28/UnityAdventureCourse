using _31.Scripts.Components.Weapons.RangeWeapon.Config;
using _31.Scripts.Components.Weapons.RangeWeapon.Interfaces;

namespace _31.Scripts.Components.Weapons.RangeWeapon
{
    public abstract class RangeWeaponFactory<TCreator, TContext, TConfig> : IRangeWeaponFactory<TContext, TConfig>
        where TCreator : IRangeWeaponCreator<TContext, TConfig>
        where TContext : RangeWeaponCreationContext
        where TConfig : RangeWeaponConfig
    {
        private readonly RangeWeaponCreatorRegistry<TCreator, TContext, TConfig> _registry;
        
        protected RangeWeaponFactory(RangeWeaponCreatorRegistry<TCreator, TContext, TConfig> registry)
        {
            _registry = registry;
        }
        
        public IRangeWeapon Create(TContext context, TConfig rangeWeaponConfig)
        {
            return _registry.Get(rangeWeaponConfig).Create(context, rangeWeaponConfig);
        }
    }
}