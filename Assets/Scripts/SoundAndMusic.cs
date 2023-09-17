using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundAndMusic : MonoBehaviour
{
    public static SoundAndMusic Instance;

    public float SoundVolume { get; private set; }
    public float MusciVolume { get; private set; }

    public static UnityEvent SoundOrMusicChanged = new UnityEvent();

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        Repository.DataLoaded.AddListener(LoadData);
    }

    public void LoadData()
    {
        SoundVolume = Repository.Instance.GameData.SoundVolume;
        MusciVolume = Repository.Instance.GameData.MusicVolume;

        SoundOrMusicChanged.Invoke();
    }

    public void ChangeSound()
    {
        SoundVolume = SoundVolume > 0f ? 0f : 1f;

        SoundOrMusicChanged.Invoke();
    }

    public void ChangeMusic()
    {
        MusciVolume = MusciVolume > 0f ? 0f : 1f;

        SoundOrMusicChanged.Invoke();
    }    
}
