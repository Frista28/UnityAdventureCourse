using _31.Scripts.Components.Health.Interfaces;
using _31.Scripts.Components.Teams;
using _31.Scripts.Infrastructure.Utils;
using UnityEngine;

namespace _31.Scripts.Components
{
    // КОСТЫЛЬ! Но из-за того, что не могу нормально подружить коллизию с CharacterController
    public class ContactDamage : MonoBehaviour
    {
        [SerializeField] private float _damage;
        
        private TeamMember _myTeamMember;

        private void Awake()
        {
            _myTeamMember = GameObjectUtils.GetRequiredComponentInSelfOrParent<TeamMember>(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!GameObjectUtils.TryGetComponentInSelfOrParent(
                    other.gameObject,
                    out IDamageable damageableTarget))
                return;
            
            if (!GameObjectUtils.TryGetComponentInSelfOrParent(
                    other.gameObject,
                    out TeamMember targetTeamMember))
                return;

            if (_myTeamMember.TeamId == targetTeamMember.TeamId)
                return;

            damageableTarget.TakeDamage(_damage);
        }
    }
}