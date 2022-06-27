using UnityEngine;

public class CharacterSFX : MonoBehaviour
{
    private AudioSource death;

    private void Awake()
    {
        death = GetComponent<AudioSource>();
    }
    
    private void Start()
    {
        death.mute = DataBetweenScenes.instance.mute;
    }

    private void OnEnable()
    {
        UIAudioSettings.MuteAudio += Mute;
        CharacterDeath.NotifyDeath += PlaySound;
    }

    private void OnDisable()
    {
        UIAudioSettings.MuteAudio -= Mute;
        CharacterDeath.NotifyDeath -= PlaySound;
    }

    private void PlaySound()
    {
        death.Play();
    }
    
    private void Mute()
    {
        death.mute = death.mute != true;
    }
}
