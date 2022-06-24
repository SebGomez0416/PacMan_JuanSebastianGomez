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
   }

   private void OnDisable()
   {
      UIAudioSettings.MuteAudio -= Mute;
      UIAudioSettings.SendVolume -= Volume;
   }

   private void Volume(float v)
   {
      _audioSource.volume = v;
   }

   private void Mute()
   {
      _audioSource.mute = _audioSource.mute != true;
   }
}
