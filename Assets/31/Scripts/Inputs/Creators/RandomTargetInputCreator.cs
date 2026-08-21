using _31.Scripts.Inputs.Configs.Movement;
using _31.Scripts.Inputs.Interfaces;
using _31.Scripts.Targets.Interfaces;
using UnityEngine;

namespace _31.Scripts.Inputs.Creators
{
    public class RandomTargetInputCreator
    {
        private readonly ITargetProvider _targetProvider;

        public RandomTargetInputCreator(ITargetProvider targetProvider) => _targetProvider = targetProvider;

        public IMovementInput Create(Transform self, RandomTargetInputConfig config) =>
            new RandomMovementInputInZone(config.TimeToChange, _targetProvider.Target, self, config.Offset);
    }
}