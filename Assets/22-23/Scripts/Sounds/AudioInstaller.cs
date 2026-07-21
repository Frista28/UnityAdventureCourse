using _22_23.Scripts.Sounds;
using UnityEngine;
using UnityEngine.Audio;

public class AudioInstaller : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    
    [SerializeField] private AudioSettingsView _settingsView;
    
    private AudioService _audioService;
    private AudioSettingsController _settingsController;

    private void Start()
    {
        _audioService = new AudioService(_audioMixer);

        _settingsController = new AudioSettingsController(_audioService);
        
        _settingsView.Initialized(_settingsController);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _settingsController.ToggleSound();
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
            _settingsController.ToggleEffects();
    }
}
