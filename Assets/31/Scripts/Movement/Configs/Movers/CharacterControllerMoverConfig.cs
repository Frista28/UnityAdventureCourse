using UnityEngine;

namespace _31.Scripts.Movement.Configs.Movers
{
    [CreateAssetMenu(fileName = "CharacterControllerMoverConfig", menuName = "Movement/Movers/CharacterControllerMoverConfig")]
    public class CharacterControllerMoverConfig : MoverConfig
    {
        [field: SerializeField] public float Speed { get; private set; }
        
        [field: SerializeField] public float Gravity { get; private set; }
    }
}