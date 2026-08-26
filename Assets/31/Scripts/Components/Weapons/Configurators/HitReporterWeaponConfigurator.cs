using _31.Scripts.Components.Weapons.Interfaces;
using _31.Scripts.Hits.Data;
using _31.Scripts.Hits.Service.Interfaces;

namespace _31.Scripts.Components.Weapons.Configurators
{
    public class HitReporterWeaponConfigurator<THitData> : IWeaponConfigurator<IHitReporterConsumer<THitData>>
        where THitData : HitData
    {
        private readonly IHitReporter<THitData> _reporter;

        public HitReporterWeaponConfigurator(IHitReporter<THitData> reporter)
        {
            _reporter = reporter;
        }

        public void Configure(IHitReporterConsumer<THitData> weapon)
        {
            weapon.SetHitReporter(_reporter);
        }
    }
}