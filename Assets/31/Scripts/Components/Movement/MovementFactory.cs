using System;
using _31.Scripts.Components.Movement.Configs.Movers;
using _31.Scripts.Components.Movement.Configs.Rotators;
using _31.Scripts.Components.Movement.Mover;
using _31.Scripts.Components.Movement.Rotator;
using UnityEngine;

namespace _31.Scripts.Components.Movement
{
    public class MovementFactory
    {
        public Movement Create(
            MonoBehaviour monoBehaviour,
            MoverConfig moverConfig,
            RotatorConfig rotatorConfig)
        {
            IMover mover;
            
            switch (moverConfig)
            {
                case CharacterControllerMoverConfig config:
                    if (!monoBehaviour.TryGetComponent(out CharacterController characterController))
                        throw new InvalidOperationException(
                            $"MonoBehaviour '{monoBehaviour.name}' requires a CharacterController " +
                            $"for {nameof(CharacterControllerMoverConfig)}.");
                    
                    mover = new CharacterControllerMover(characterController, config.Speed, config.Gravity);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(moverConfig), moverConfig, null);
            }

            IRotator rotator;

            switch (rotatorConfig)
            {
                case TransformRotatorConfig config:
                    rotator = new TransformRotator(monoBehaviour.transform, config.RotationSpeed);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(rotatorConfig), rotatorConfig, null);
            }
            
            return new Movement(mover, rotator);
        }
    }
}