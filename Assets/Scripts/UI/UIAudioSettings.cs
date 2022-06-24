using UnityEngine;
using UnityEngine.UI;
using System;

public class UIAudioSettings : MonoBehaviour
{
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private Slider slider;
    
    public static event Action <float> SendVolume;
    public static event Action MuteAudio;
    public static event Action <bool> IsActiveSettings;
    
    
    public void SettingsButton(bool set)
    {
        IsActiveSettings?.Invoke(set);
        settingsScreen.SetActive(set);
    }

    public void MuteButton()
    {
        MuteAudio?.Invoke();
    }

    public void VolumeSlider()
    {
        SendVolume?.Invoke(slider.value); 
    }

   
}
