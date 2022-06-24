using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject creditsScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private Slider slider;
    
    public static event Action <float> SendVolume;
    public static event Action MuteAudio;

    public void PlayButton()
    {
        SceneManager.LoadScene("LvOne");
    }

    public void CreditsButton(bool set)
    {
        creditsScreen.SetActive(set);
    }
    
    public void SettingsButton(bool set)
    {
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

    public void ExitButton()
    {
        Application.Quit();
    }
}
