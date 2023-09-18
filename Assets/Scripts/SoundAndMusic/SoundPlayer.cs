using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance { get; private set; }

    [SerializeField] private Sounds _sounds;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
    }

    public void Play(string name)
    {
        foreach (Sound sound in _sounds.SoundList)
        {
            if (sound.Name == name)
            {
                Instantiate(sound.Object);

                return;
            }
        }
    }
}