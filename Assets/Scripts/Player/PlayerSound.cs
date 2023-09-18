using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(PlayerMovement))]
public class PlayerSound : MonoBehaviour
{
    private AudioSource _audioSource;
    private PlayerMovement _movement;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _movement = GetComponent<PlayerMovement>();

        Repository.DataLoaded.AddListener(LoadData);
    }

    private void Update()
    {
        if (_movement.IsMoving()) _audioSource.enabled = true;
        else _audioSource.enabled = false;
    }

    private void LoadData()
    {
        _audioSource.volume = Repository.Instance.GameData.SoundVolume;
    }
}
