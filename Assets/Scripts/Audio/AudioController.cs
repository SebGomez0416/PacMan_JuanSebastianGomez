using UnityEngine;

public class AudioController : MonoBehaviour
{
   private AudioSource _audioSource;

   private void Awake()
   {
      _audioSource = GetComponent<AudioSource>();
   }
   private void OnEnable()
   {
      UIAudioSettings.MuteAudio += Mute;
      UIAudioSettings.SendVolume += Volume;
      UIAudioSettings.InitAudio += init;
   }

   private void OnDisable()
   {
      UIAudioSettings.MuteAudio -= Mute;
      UIAudioSettings.SendVolume -= Volume;
      UIAudioSettings.InitAudio -= init;
   }
   
   private void init()
   {
      _audioSource.volume = DataBetweenScenes.instance.Volume;
      _audioSource.mute = DataBetweenScenes.instance.mute;
   }

   private void Volume(float v)
   {
      _audioSource.volume = v;
      DataBetweenScenes.instance.Volume = _audioSource.volume;
   }

   private void Mute()
   {
      _audioSource.mute = _audioSource.mute != true;
      DataBetweenScenes.instance.mute = _audioSource.mute;
   }
}
