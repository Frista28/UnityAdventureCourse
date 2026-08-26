using UnityEngine;

namespace _31.Scripts.Components.Movement.Configs.Rotators
{
    [CreateAssetMenu(fileName = "TransformRotatorConfig", menuName = "Movement/Rotators/TransformRotator")]
    public class TransformRotatorConfig : RotatorConfig
    {
        [field: SerializeField] public float RotationSpeed { get; private set; }
    }
}