using _31.Scripts.Infrastructure.Teams;
using UnityEngine;

namespace _31.Scripts.Components.Teams
{
    public class TeamMember : MonoBehaviour
    {
        [SerializeField] private TeamId _teamId;
        
        public TeamId TeamId => _teamId;
    }
}