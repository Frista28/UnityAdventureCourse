using _31.Scripts.Components.Weapons.RangeWeapon.Config;
using _31.Scripts.Hits.Data.Config;
using UnityEngine;

namespace _31.Scripts.Components.Weapons.RangeWeapon.Hit.Config
{
    [CreateAssetMenu(fileName = "HitRangeWeaponConfig", menuName = "Components/Weapon/RangeWeapon/Hit/HitRangeWeaponConfig")]
    public class HitRangeWeaponConfig : RangeWeaponConfig
    {
        [field: SerializeField] public RangeWeaponConfig RangeWeaponConfig { get; private set; }
        
        [field: SerializeField] public HitDataConfig HitDataConfig { get; private set; }
    }
}