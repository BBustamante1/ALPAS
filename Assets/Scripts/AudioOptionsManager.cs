using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptionsManager : MonoBehaviour
{
    public static float musicVolume { get; private set; }
    public static float soundEffectsVolume { get; private set; }

    public Slider soundEffectsSlider;

    public Slider musicSlider;

    private void Start()
    {
        soundEffectsSlider.value = PlayerPrefs.GetFloat("SoundEffects", 0.75f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    public void OnMusicSliderValueChange(float value)
    {
        musicVolume = value;
        MusicManager.instance.UpdateMusicMixerVolume();
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void OnSoundEffectsSliderValueChange(float value)
    {
        soundEffectsVolume = value;
        AudioManager.instance.UpdateSoundMixerVolume();
        PlayerPrefs.SetFloat("SoundEffects", soundEffectsVolume);
    }
}
