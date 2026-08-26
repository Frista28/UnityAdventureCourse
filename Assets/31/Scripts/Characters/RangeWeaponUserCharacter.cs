using _31.Scripts.Components.Teams;
using _31.Scripts.Components.Weapons.Interfaces;
using _31.Scripts.Components.Weapons.RangeWeapon.Interfaces;
using _31.Scripts.Infrastructure.Utils;
using UnityEngine;

namespace _31.Scripts.Characters
{
    [RequireComponent(typeof(TeamMember))]
    public class RangeWeaponUserCharacter : Character, IRangeWeaponOwner, IWeaponUser
    {
        [SerializeField] private Transform _firePoint;
        
        private IWeapon _weapon;
        
        private TeamMember _myTeamMember;

        public Transform GetFirePoint() => _firePoint;

        public void InitializeWeapon(IWeapon weapon) => _weapon = weapon;

        public void UseWeapon() => _weapon.Use();

        private void Awake()
        {
            _myTeamMember = GameObjectUtils.GetRequiredComponentInSelfOrParent<TeamMember>(gameObject);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                UseWeapon();
            }
        }
    }
}