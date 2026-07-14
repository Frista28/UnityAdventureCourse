using _22_23.Scripts.Enums;
using UnityEngine;

namespace _22_23.Scripts.Structs
{
    public struct DamageInfo
    {
        public float amount;
        public DamageType damageType;
        public GameObject source;

        public DamageInfo(float amount, DamageType damageType, GameObject source)
        {
            this.amount = amount;
            this.damageType = damageType;
            this.source = source;
        }
    }
}