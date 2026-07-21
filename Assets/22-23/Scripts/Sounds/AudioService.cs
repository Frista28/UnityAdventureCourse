using UnityEngine.Audio;

public class AudioService
{
    private const string SoundVolume = nameof(SoundVolume);
    private const string EffectVolume = nameof(EffectVolume);

    private const float AudioVolumeOn = 0f;
    private const float AudioVolumeOff = -80f;
    
    private readonly AudioMixer _audioMixer;

    public AudioService(AudioMixer audioMixer)
    {
        _audioMixer = audioMixer;
    }

    public void SetSoundsEnabled(bool enabled)
    {
        if (enabled)
            _audioMixer.SetFloat(SoundVolume, AudioVolumeOn);
        else
            _audioMixer.SetFloat(SoundVolume, AudioVolumeOff);
    }

    public void SetEffectsEnabled(bool enabled)
    {
        if (enabled)
            _audioMixer.SetFloat(EffectVolume, AudioVolumeOn);
        else
            _audioMixer.SetFloat(EffectVolume, AudioVolumeOff);
    }
}
