using UnityEngine;

public class EnemySFX : MonoBehaviour
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
        EnemyDeath.NotifyDeath += PlaySound;
    }

    private void OnDisable()
    {
        UIAudioSettings.MuteAudio -= Mute;
        EnemyDeath.NotifyDeath -= PlaySound;
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
