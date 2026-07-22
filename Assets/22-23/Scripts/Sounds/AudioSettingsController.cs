namespace _22_23.Scripts.Sounds
{
    public class AudioSettingsController
    {
        private readonly AudioService _audioService;
        
        private bool _soundEnabled;
        private bool _effectsEnabled;

        public AudioSettingsController(AudioService audioService)
        {
            _audioService = audioService;
            
            _soundEnabled = true;
            _effectsEnabled = true;
            
            ApplySettings();
        }
        
        public bool SoundEnabled => _soundEnabled;
        
        public bool EffectsEnabled => _effectsEnabled;

        public void ToggleSound()
        {
            _soundEnabled = !_soundEnabled;

            ApplySettings();
        }

        public void ToggleEffects()
        {
            _effectsEnabled = !_effectsEnabled;

            ApplySettings();
        }

        private void ApplySettings()
        {
            _audioService.SetSoundsEnabled(_soundEnabled);
            _audioService.SetEffectsEnabled(_effectsEnabled);
        }
    }
}