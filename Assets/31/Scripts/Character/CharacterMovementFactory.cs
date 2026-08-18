using _31.Scripts.Movable;
using UnityEngine;

namespace _31.Scripts.Character
{
    public class CharacterMovementFactory
    {
        public Movable.CharacterMovement CreatePlayerCharacterMovement(
            CharacterController controller,
            Transform transform,
            Vector3 spawnPosition,
            float moveSpeed,
            float rotationSpeed)
        {
            CharacterControllerMover mover = new CharacterControllerMover(controller, moveSpeed, -20f);
            DirectRotator rotator = new DirectRotator(transform, rotationSpeed);

            Movable.CharacterMovement characterMovement = new Movable.CharacterMovement(mover, rotator);
            
            return characterMovement;
        }
    }
}