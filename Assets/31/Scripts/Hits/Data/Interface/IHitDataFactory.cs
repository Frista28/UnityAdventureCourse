using _31.Scripts.Hits.Data.Config;

namespace _31.Scripts.Hits.Data.Interface
{
    public interface IHitDataFactory<out THitData, in THitDataConfig>
        where THitData : HitData
        where THitDataConfig : HitDataConfig
    {
        THitData Create(HitData hitData, THitDataConfig hitDataConfig);
    }
}