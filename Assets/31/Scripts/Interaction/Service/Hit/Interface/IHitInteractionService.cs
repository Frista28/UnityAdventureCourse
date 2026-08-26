using _31.Scripts.Hits.Data;
using _31.Scripts.Hits.Data.CustomData.Damage;
using _31.Scripts.Hits.Service.Interfaces;
using _31.Scripts.Interaction.Service.Interface;
using UnityEngine;

namespace _31.Scripts.Interaction.Service.Hit.Interface
{
    public interface IHitInteractionService<THitData> : IInteractionService
    where THitData : HitData
    {
        IHitReporter<THitData> CreateReporter(GameObject source);
        
        void Interact(THitData hitData);
    }
}