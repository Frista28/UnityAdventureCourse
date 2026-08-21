using _31.Scripts.Components.Health.Configs;
using _31.Scripts.Movement.Configs.Movers;
using _31.Scripts.Movement.Configs.Rotators;
using UnityEngine;

namespace _31.Scripts.Characters.Configs
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Characters/Character")]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public MoverConfig MoverConfig { get; private set; }
        
        [field: SerializeField] public RotatorConfig RotatorConfig { get; private set; }
        
        [field: SerializeField] public HealthConfig HealthConfig { get; private set; }
    }
}