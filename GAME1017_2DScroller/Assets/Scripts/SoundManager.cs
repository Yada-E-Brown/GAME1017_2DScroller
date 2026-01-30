using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private SoundManager() { }
    private static SoundManager soundInstance = null;
    public static SoundManager GetInstance()
    {
        if(soundInstance == null)
        {
            soundInstance = FindAnyObjectByType<SoundManager>();
        }
        return soundInstance;
    }

    public AudioMixer mixer;

    //Changes Master volume in Audio Mixer
    public void SetTotalVolume(float volume)
    {
        mixer.SetFloat("Master", volume);
    }

    //Changes Sfx volume in Audio Mixer
    public void SetSfxVolume(float volume)
    {
        mixer.SetFloat("Sfx", volume);
    }

    //Changes Music volume in Audio Mixer
    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("Music", volume);
    }

}
