using System;
using System.Collections.Generic;
using _31.Scripts.Components.Weapons.RangeWeapon.Config;
using _31.Scripts.Components.Weapons.RangeWeapon.Interfaces;

namespace _31.Scripts.Components.Weapons.RangeWeapon
{
    public class RangeWeaponCreatorRegistry<TCreator, TContext, TConfig> 
        where TCreator : IRangeWeaponCreator<TContext, TConfig>
        where TContext : RangeWeaponCreationContext
        where TConfig : RangeWeaponConfig
    {
        private readonly Dictionary<Type, TCreator> _creators = new();

        public void Register(TCreator creator) => _creators.Add(typeof(TConfig), creator);

        public TCreator Get(RangeWeaponConfig config)
        {
            if (!_creators.TryGetValue(config.GetType(), out var creator))
                throw new ArgumentException($"No creator registered for {config.GetType().Name}");

            return creator;
        }
    }
}