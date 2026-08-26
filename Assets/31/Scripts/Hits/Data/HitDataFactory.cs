using _31.Scripts.Hits.Data.Config;
using _31.Scripts.Hits.Data.Interface;

namespace _31.Scripts.Hits.Data
{
    public class HitDataFactory : IHitDataFactory<HitData, HitDataConfig>
    {
        public HitData Create(HitData hitData, HitDataConfig hitDataConfig) => hitData;
    }
}