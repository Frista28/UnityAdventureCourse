using UnityEngine;

namespace _31.Scripts.Movable
{
    public class CharacterMovementFactory
    {
        public CharacterMovement CreatePlayerCharacterMovement(
            CharacterController controller,
            Transform transform,
            float moveSpeed,
            float rotationSpeed)
        {
            CharacterControllerMover mover = new CharacterControllerMover(controller, moveSpeed, -20f);
            DirectRotator rotator = new DirectRotator(transform, rotationSpeed);

            CharacterMovement characterMovement = new CharacterMovement(mover, rotator);
            
            return characterMovement;
        }
    }
}