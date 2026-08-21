using UnityEngine;

namespace _31.Scripts.Inputs.Configs.Movement
{
    [CreateAssetMenu(fileName = "RandomCharacterInputConfig", menuName = "Inputs/Configs/RandomCharacterInputConfig")]
    public class RandomTargetInputConfig : MovementInputConfig
    {
        [field: SerializeField] public float TimeToChange { get; private set; }

        [field: SerializeField] public float Offset { get; private set; }
    }
}