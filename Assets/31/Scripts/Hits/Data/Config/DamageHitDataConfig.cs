using UnityEngine;

namespace _31.Scripts.Hits.Data.Config
{
    [CreateAssetMenu(fileName = "DamageHitDataConfig", menuName = "Hits/DamageHitDataConfig")]
    public class DamageHitDataConfig : HitDataConfig
    {
        [field: SerializeField] public float Damage { get; private set; }
    }
}