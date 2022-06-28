using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> audioClips;

    public static event Action LoadPref;

    private void Awake()
   {
      _audioSource = GetComponent<AudioSource>();
   }
   private void OnEnable()
   {
      UIAudioSettings.MuteAudio += Mute;
      UIAudioSettings.SendVolume += Volume;
      UIAudioSettings.InitAudio += init;
      Lives.PlaySound += ChangeAudioClip;
      Score.PlaySound += ChangeAudioClip;
   }

   private void OnDisable()
   {
      UIAudioSettings.MuteAudio -= Mute;
      UIAudioSettings.SendVolume -= Volume;
      UIAudioSettings.InitAudio -= init;
      Lives.PlaySound -= ChangeAudioClip;
      Score.PlaySound -= ChangeAudioClip;
   }
   
   private void init()
   {
        LoadPref?.Invoke();
      _audioSource.volume = DataBetweenScenes.instance.Volume;
      _audioSource.mute = DataBetweenScenes.instance.mute;
   }

   private void ChangeAudioClip(string name)
   {
      foreach (var clip in audioClips)
      {
         if (clip.name == name)
            _audioSource.clip = clip;
      }

      _audioSource.loop = false;
      _audioSource.Play();
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
