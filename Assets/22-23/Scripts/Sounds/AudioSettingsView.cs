using UnityEngine;

namespace _22_23.Scripts.Sounds
{
    public class AudioSettingsView : MonoBehaviour
    {
        private AudioSettingsController _settingsController;

        public void Initialized(AudioSettingsController settingsController)
        {
            _settingsController = settingsController;
        }

        public void ToggleSound() => _settingsController.ToggleSound();
        
        public void ToggleEffects() => _settingsController.ToggleEffects();

    }
}