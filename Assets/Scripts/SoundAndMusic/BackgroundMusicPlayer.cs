using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicPlayer : MonoBehaviour
{
    public static BackgroundMusicPlayer Instance { get; private set; }

    [SerializeField] private AudioClip _clip;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;

        DontDestroyOnLoad(gameObject);

        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _clip;
        Play();

        Repository.DataLoaded.AddListener(loadData);
    }

    private void loadData()
    {
        _audioSource.volume = Repository.Instance.GameData.MusicVolume;
    }

    public void Pause() => _audioSource.Pause();
    public void Play() => _audioSource.Play();
}
