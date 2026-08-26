using _31.Scripts.Components.Weapons.Interfaces;
using _31.Scripts.Hits.Data;

namespace _31.Scripts.Hits.Service.Interfaces
{
    public interface IHitReporterConsumer<THitData> : IWeapon where THitData : HitData
    {
        void SetHitReporter(IHitReporter<THitData> hitReporter);
    }
}