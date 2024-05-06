using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("=============Source==============")]
    [SerializeField] AudioSource backgroundSource;
    [SerializeField] AudioSource soundEffectSource;

    [Header("==============Clip===============")]
    public AudioClip Background;

    private void Start()
    {
        instance = this;
        backgroundSource.clip = Background;
        backgroundSource.Play();
    }

    public void PlaySoundEffects(AudioClip clip)
    {
        soundEffectSource.PlayOneShot(clip);
    }
}
