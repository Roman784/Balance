using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsMenu : Menu
{
    [Space]

    [SerializeField] private TMP_Text _soundValueText;
    [SerializeField] private TMP_Text _musicValueText;

    [Space]

    [SerializeField] private GameObject _clearDataConfirm;

    private SoundAndMusic _soundAndMusic;

    private void Start()
    {
        _soundAndMusic = SoundAndMusic.Instance;

        UpdateDisplay();
    }

    public void ChangeSound()
    {
        _soundAndMusic.ChangeSound();

        UpdateDisplay();
    }

    public void CahngeMusic()
    {
        _soundAndMusic.ChangeMusic();

        UpdateDisplay();
    }

    public void ChangeLanguage()
    {

    }

    public void ClearData()
    {
        _clearDataConfirm.SetActive(!_clearDataConfirm.activeSelf);
    }

    public void ConfirmDataClearing()
    {
        GoToMainMenu();
    }

    private void UpdateDisplay ()
    {
        _soundValueText.text = _soundAndMusic.SoundVolume > 0f ? "on" : "off";
        _musicValueText.text = _soundAndMusic.MusciVolume > 0f ? "on" : "off";
    }
}
