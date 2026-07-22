using _22_23.Scripts.Character;
using UnityEngine;

namespace _22_23.Scripts.Controller
{
    public class TargetFollowController
    {
        private readonly PlayerAgentCharacter _character;

        public TargetFollowController(PlayerAgentCharacter character)
        {
            _character = character;
        }
        
        public Vector3 TargetPosition { get; private set; }

        public bool IsReachedTargetPosition => _character.IsPathComplete();

        public void SetTarget(Vector3 targetPosition)
        {
            TargetPosition = targetPosition;
            
            _character.SetDestination(targetPosition);
        }
    }
}