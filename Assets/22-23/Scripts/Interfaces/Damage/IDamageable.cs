using _22_23.Scripts.Structs;
using UnityEngine;

namespace _22_23.Scripts.Interfaces.Damage
{
    public interface IDamageable
    {
        public void TakeDamage(DamageInfo damageInfo);
    }
}