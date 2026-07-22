using UnityEngine;
using UnityEngine.AI;

namespace _22_23.Scripts.Movable
{
    public class AgentDirectionMover
    {
        private readonly NavMeshAgent _agent;
        
        public AgentDirectionMover(NavMeshAgent agent, float moveSpeed)
        {
            _agent = agent;
            _agent.speed = moveSpeed;
        }

        public Vector3 Direction => _agent.desiredVelocity;

        public void MoveTo(Vector3 position) => _agent.SetDestination(position);
    }
}