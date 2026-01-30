using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeSlider : MonoBehaviour
{
    public void SetMusicVolume(float volume)
    {
        SoundManager.GetInstance().SetMusicVolume(volume);
    }

    public void SetSfxVolume(float volume)
    {
        SoundManager.GetInstance().SetSfxVolume(volume);
    }

}   
