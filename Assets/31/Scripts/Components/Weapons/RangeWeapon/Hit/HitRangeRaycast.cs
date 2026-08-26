using System;
using _31.Scripts.Components.Weapons.RangeWeapon.Config;
using _31.Scripts.Hits.Data;
using _31.Scripts.Hits.Data.Config;
using _31.Scripts.Hits.Data.Interface;
using _31.Scripts.Hits.Service.Interfaces;
using UnityEngine;

namespace _31.Scripts.Components.Weapons.RangeWeapon.Hit
{
    public class HitRangeRaycast<THitData, THitDataConfig> : RangeRaycast
        where THitData : HitData
        where THitDataConfig : HitDataConfig
    {
        private readonly IHitDataFactory<THitData, THitDataConfig> _hitDataFactory;
        private readonly THitDataConfig _hitDataConfig;
        private readonly IHitReporter<THitData> _hitReporter;

        public HitRangeRaycast(IHitDataFactory<THitData, THitDataConfig> hitDataFactory, THitDataConfig hitDataConfig, IHitReporter<THitData> hitReporter, Transform firePoint, RangeRaycastConfig rangeRaycastConfig) :  base(firePoint, rangeRaycastConfig)
        {
            _hitDataFactory = hitDataFactory ?? throw new ArgumentNullException(nameof(hitDataFactory));
            _hitReporter = hitReporter ?? throw new ArgumentNullException(nameof(hitReporter));
            _hitDataConfig = hitDataConfig ?? throw new ArgumentNullException(nameof(hitDataConfig));
        }

        protected override void OnRaycastHit(RaycastHit hit)
        {
            HitData hitData = new HitData(hit.collider.gameObject, hit.point, hit.normal);
                
            _hitReporter.Report(_hitDataFactory.Create(hitData, _hitDataConfig));
        }
    }
}