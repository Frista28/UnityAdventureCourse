using System;
using _31.Scripts.Hits.Data;

namespace _31.Scripts.Hits.Service.Interfaces
{
    public interface IHitReporter<THitData> where THitData : HitData
    {
        public event Action<THitData> OnHit;

        public void Report(THitData data);
    }
}