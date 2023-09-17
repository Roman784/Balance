using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAndMusic : MonoBehaviour
{
    public static SoundAndMusic Instance;

    public float SoundVolume { get; private set; }
    public float MusciVolume { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        
    }

    public void LoadData()
    {

    }

    public void ChangeSound()
    {
        SoundVolume = SoundVolume > 0f ? 0f : 1f;
    }

    public void ChangeMusic()
    {
        MusciVolume = MusciVolume > 0f ? 0f : 1f;
    }    
}
