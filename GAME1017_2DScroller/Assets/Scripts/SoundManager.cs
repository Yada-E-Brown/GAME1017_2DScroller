using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer mixer;

    public AudioClip deathSfx;

    private AudioSource sfxSource;

    private void Awake()
    {
        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.outputAudioMixerGroup = null; 
    }

    public void PlaySfx(AudioClip clip)
    {
        if (sfxSource == null)
            sfxSource.PlayOneShot(clip);
    }

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("Music", value);
    }

    public void SetSfxVolume(float value)
    {
        mixer.SetFloat("Sfx", value);
    }
}