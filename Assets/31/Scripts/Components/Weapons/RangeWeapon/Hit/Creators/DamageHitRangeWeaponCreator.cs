using System;
using _31.Scripts.Components.Weapons.RangeWeapon.Config;
using _31.Scripts.Components.Weapons.RangeWeapon.Hit.Config;
using _31.Scripts.Components.Weapons.RangeWeapon.Interfaces;
using _31.Scripts.Hits.Data.Config;
using _31.Scripts.Hits.Data.CustomData.Damage;
using _31.Scripts.Hits.Service.Interfaces;
using _31.Scripts.Interaction.Service.Hit.Interface;

namespace _31.Scripts.Components.Weapons.RangeWeapon.Hit.Creators
{
    public class DamageHitRangeWeaponCreator : IRangeWeaponCreator<HitRangeWeaponCreationContext, HitRangeWeaponConfig>
    {
        private readonly HitRangeWeaponBuilder<DamageHitData, DamageHitDataConfig> _builder;

        private readonly IHitInteractionService<DamageHitData> _damageHitInteractionService;

        public DamageHitRangeWeaponCreator(HitRangeWeaponBuilder<DamageHitData, DamageHitDataConfig> builder, IHitInteractionService<DamageHitData> damageHitInteractionService)
        {
            _builder = builder;
            _damageHitInteractionService = damageHitInteractionService;
        }

        public IRangeWeapon Create(HitRangeWeaponCreationContext context, HitRangeWeaponConfig hitRangeWeaponConfig)
        {
            
            DamageHitDataConfig damageHitDataConfig = hitRangeWeaponConfig.HitDataConfig as DamageHitDataConfig 
                                                      ?? throw new ArgumentException($"Expected {nameof(DamageHitDataConfig)}, but received {hitRangeWeaponConfig.GetType().Name}");

            RangeWeaponConfig rangeWeaponConfig = hitRangeWeaponConfig.RangeWeaponConfig;
            
            IHitReporter<DamageHitData> reporter = _damageHitInteractionService.CreateReporter(context.Source);
            
            return _builder.Create(context, reporter, rangeWeaponConfig, damageHitDataConfig);
        }
    }
}