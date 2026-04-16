using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        musicSlider.onValueChanged.AddListener((value) =>
        {
           SoundManager.Instance.SetMusicVolume(value);
        });

        sfxSlider.onValueChanged.AddListener((value) =>
        {
            SoundManager.Instance.SetSfxVolume(value);
        });
    }
}