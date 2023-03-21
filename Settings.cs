using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.Rendering.PostProcessing;
public class Settings : MonoBehaviour
{
    public AudioMixer MainMixer;
    public TMP_Dropdown Graphics;
    public Slider VolumeSlider;
    private const string MASTER_VOLUME_KEY = "MasterVolume";
    public PostProcessVolume postProcessVolume;
    public Button Mute, UnMute;
    void Start()
    {
        if (PlayerPrefs.HasKey(MASTER_VOLUME_KEY))
        {
            float volume = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
            VolumeSlider.value = volume;
            SetVolume(volume);
        }
        if (PlayerPrefs.HasKey("qualityIndex"))
        {
            int quality = PlayerPrefs.GetInt("qualityIndex", 2);
            SetQuality(quality);
            Graphics.value = quality;
        }
        if (PlayerPrefs.HasKey("Mute"))
        {
            if (PlayerPrefs.GetInt("Mute") == 1)
            {
                MuteAudio();
            }
            else
            {
                UnMuteAudio();
            }
        }


    }
    public void SetVolume(float volume)
    {
        MainMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityIndex", qualityIndex);
        PlayerPrefs.Save();

    }
    public void MuteAudio()
    {
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Mute", 1);
        Mute.gameObject.SetActive(false);
        UnMute.gameObject.SetActive(true);
    }
    public void UnMuteAudio()
    {
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Mute", 0);
        Mute.gameObject.SetActive(true);
        UnMute.gameObject.SetActive(false);
    }
}
