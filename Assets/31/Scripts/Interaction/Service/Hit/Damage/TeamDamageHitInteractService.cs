using _31.Scripts.Components.Health.Interfaces;
using _31.Scripts.Components.Teams;
using _31.Scripts.Hits.Data.CustomData.Damage;
using _31.Scripts.Hits.Service;
using _31.Scripts.Hits.Service.Interfaces;
using _31.Scripts.Infrastructure.Utils;
using _31.Scripts.Interaction.Service.Hit.Interface;
using UnityEngine;

namespace _31.Scripts.Interaction.Service.Hit.Damage
{
    public class TeamDamageHitInteractService : IHitInteractionService<DamageHitData>
    {
        public IHitReporter<DamageHitData> CreateReporter(GameObject source)
        {
            IHitReporter<DamageHitData> reporter = new HitReporter<DamageHitData>(source);

            reporter.OnHit += Interact;
            
            return reporter;
        }
        
        public void Interact(DamageHitData hitData)
        {
            if (!GameObjectUtils.TryGetComponentInSelfOrParent(
                    hitData.Target,
                    out IDamageable damageableTarget))
                return;
            
            if (!GameObjectUtils.TryGetComponentInSelfOrParent(
                    hitData.Target,
                    out TeamMember targetTeamMember))
                return;

            if (!GameObjectUtils.TryGetComponentInSelfOrParent(
                    hitData.Source,
                    out TeamMember sourceTeamMember))
                return;

            if (sourceTeamMember.TeamId == targetTeamMember.TeamId)
                return;

            damageableTarget.TakeDamage(hitData.Damage);
        }
    }
}