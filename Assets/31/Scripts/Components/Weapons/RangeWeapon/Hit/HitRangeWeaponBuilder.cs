using System;
using _31.Scripts.Components.Weapons.RangeWeapon.Config;
using _31.Scripts.Components.Weapons.RangeWeapon.Interfaces;
using _31.Scripts.Hits.Data;
using _31.Scripts.Hits.Data.Config;
using _31.Scripts.Hits.Data.Interface;
using _31.Scripts.Hits.Service.Interfaces;

namespace _31.Scripts.Components.Weapons.RangeWeapon.Hit
{
    public class HitRangeWeaponBuilder<THitData, THitDataConfig> 
        where THitData : HitData
        where THitDataConfig : HitDataConfig
    {
        private readonly IHitDataFactory<THitData, THitDataConfig> _hitDataFactory;
        
        public HitRangeWeaponBuilder(IHitDataFactory<THitData, THitDataConfig> hitDataFactory)
        {
            _hitDataFactory = hitDataFactory;
        }
        
        public IRangeWeapon Create(RangeWeaponCreationContext context, IHitReporter<THitData> reporter, RangeWeaponConfig rangeWeaponConfig, THitDataConfig hitDataConfig)
        {
            return rangeWeaponConfig switch
            {
                RangeRaycastConfig config => new HitRangeRaycast<THitData, THitDataConfig>(_hitDataFactory, hitDataConfig, reporter, context.FirePoint, config),
                _ => throw new ArgumentException("Unknown range weapon config")
            };
        }
    }
}