using System;
using _31.Scripts.Hits.Data;
using _31.Scripts.Hits.Service.Interfaces;
using UnityEngine;

namespace _31.Scripts.Hits.Service
{
    public class HitReporter<THitData> : IHitReporter<THitData> where THitData : HitData
    {
        public event Action<THitData> OnHit;
        
        private readonly GameObject _source;

        public HitReporter(GameObject source) => _source = source;

        public void Report(THitData data)
        {
            data.WithSource(_source);
            
            OnHit?.Invoke(data);
        }
    }
}