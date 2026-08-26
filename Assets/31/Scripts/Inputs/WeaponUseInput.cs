using _31.Scripts.Inputs.Interfaces;
using UnityEngine;

namespace _31.Scripts.Inputs
{
    public class WeaponUseInput : IWeaponInput
    {
        public bool Pressed { get; private set; }
        
        public void PressedReset() => Pressed = false;

        public void Update()
        {
            if (Pressed)
                return;
            
            if (Input.GetMouseButtonDown(0))
                Pressed = true;
        }
    }
}