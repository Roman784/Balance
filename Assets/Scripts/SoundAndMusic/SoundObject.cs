using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundObject : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _audioSource = GetComponent<AudioSource>();

        Destroy(gameObject, 5f);
    }

    public void Setup(float volume, AudioClip clip)
    {
        _audioSource.volume = volume;
        _audioSource.clip = clip;
        _audioSource.Play();

        Destroy(gameObject, clip.length);
    }
}
