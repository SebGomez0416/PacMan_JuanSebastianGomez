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
      Menu.MuteAudio += Mute;
      Menu.SendVolume += Volume;
   }

   private void OnDisable()
   {
      Menu.MuteAudio -= Mute;
      Menu.SendVolume -= Volume;
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
