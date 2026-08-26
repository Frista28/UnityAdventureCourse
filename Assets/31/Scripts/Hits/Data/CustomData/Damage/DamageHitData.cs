using UnityEngine;

namespace _31.Scripts.Hits.Data.CustomData.Damage
{
    public class DamageHitData : HitData
    {
        public float Damage { get; }
        
        public DamageHitData(GameObject target, Vector3 point, Vector3 normal, float damage) : base(target, point, normal)
        {
            Damage = damage;
        }
    }
}