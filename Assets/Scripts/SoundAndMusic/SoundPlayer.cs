using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance { get; private set; }

    [SerializeField] private Sounds _sounds;

    [Space]

    [SerializeField] private AudioSource _soundPrefab;

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
                AudioSource spawnedSound = Instantiate(_soundPrefab);

                spawnedSound.volume = Repository.Instance.GameData.SoundVolume;
                spawnedSound.clip = sound.Clip;
                spawnedSound.Play();

                Destroy(spawnedSound.gameObject, sound.Clip.length);

                return;
            }
        }
    }
}