using System;
using UnityEngine;

public class PotionSFX : MonoBehaviour
{
    private AudioSource powerUp;

    private void Awake()
    {
         powerUp= GetComponent<AudioSource>();
    }

    private void Start()
    {
        powerUp.mute = DataBetweenScenes.instance.mute;
    }

    private void OnEnable()
    {
        UIAudioSettings.MuteAudio += Mute;
       Potion.ActivePowerUp += PlaySound;
    }

    private void OnDisable()
    {
        UIAudioSettings.MuteAudio -= Mute;
        Potion.ActivePowerUp -= PlaySound;
    }

    private void PlaySound()
    {
        powerUp.Play();
    }
    
    private void Mute()
    {
        powerUp.mute = powerUp.mute != true;
    }
    
    
}
