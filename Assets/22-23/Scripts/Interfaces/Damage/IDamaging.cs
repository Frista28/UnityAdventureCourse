using UnityEngine;

namespace _22_23.Scripts.Interfaces.Damage
{
    public interface IDamaging
    {
        public void Activate(IDamageable damageable);
    }
}