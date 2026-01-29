using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    AudioSource trackMenu;

    bool isPlayingMenuTrack;

    AudioSource trackMain;

    bool isPlayingMainTrack;

    AudioSource trackSfx1;

    bool isPlayingSfx1;

    AudioSource trackSfx2;

    bool isPlayingSfx2;

    public AudioMixer mixer;

    public void SetTotalVomume(float volume)
    {
        mixer.SetFloat("Master", volume);
    }

    public void SetSfxVolume(float volume)
    {
        mixer.SetFloat("Sfx", volume);
    }

    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("Music", volume);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
