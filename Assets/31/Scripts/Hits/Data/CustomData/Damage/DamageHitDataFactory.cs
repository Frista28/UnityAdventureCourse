using _31.Scripts.Hits.Data.Config;
using _31.Scripts.Hits.Data.Interface;

namespace _31.Scripts.Hits.Data.CustomData.Damage
{
    public class DamageHitDataFactory : IHitDataFactory<DamageHitData, DamageHitDataConfig>
    {
        public DamageHitData Create(HitData hitData, DamageHitDataConfig config)
        {
            return new DamageHitData(
                hitData.Target,
                hitData.Point,
                hitData.Normal,
                config.Damage);
        }
    }
}