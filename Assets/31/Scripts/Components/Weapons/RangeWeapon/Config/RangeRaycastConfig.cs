using UnityEngine;

namespace _31.Scripts.Components.Weapons.RangeWeapon.Config
{
    [CreateAssetMenu(fileName = "RangeRaycast", menuName = "Components/Weapon/RangeWeapon/RangeRaycast")]
    public class RangeRaycastConfig : RangeWeaponConfig
    {
        [field: SerializeField] public float Range { get; private set; }
    }
}