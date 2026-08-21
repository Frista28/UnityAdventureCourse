using System;
using _31.Scripts.Inputs.Configs.Movement;
using _31.Scripts.Inputs.Creators;
using _31.Scripts.Inputs.Interfaces;
using UnityEngine;

namespace _31.Scripts.Inputs
{
    public class MovementInputFactory
    {
        private readonly KeyboardInputCreator _keyboardInputCreator = new();

        private readonly RandomTargetInputCreator _randomTargetInputCreator;

        public MovementInputFactory(RandomTargetInputCreator randomTargetInputCreator)
        {
            _randomTargetInputCreator = randomTargetInputCreator;
        }

        public IMovementInput Create(Transform self, MovementInputConfig inputConfig)
        {
            return inputConfig switch
            {
                KeyboardInputConfig => _keyboardInputCreator.Create(),
                
                RandomTargetInputConfig config => _randomTargetInputCreator.Create(self, config),

                _ => throw new ArgumentException($"Unsupported input config: {inputConfig.GetType().Name}")
            };
        }
    }
}