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

    [SerializeField] private TMP_Text _languageValueText;

    [Space]

    [SerializeField] private GameObject _clearDataConfirm;

    private SoundAndMusic _soundAndMusic;
    private Language _language;

    private void Start()
    {
        _soundAndMusic = SoundAndMusic.Instance;
        _language = Language.Instance;

        Language.LanguageChanged.AddListener(UpdateDisplay);
        SoundAndMusic.SoundOrMusicChanged.AddListener(UpdateDisplay);
    }

    public void ChangeSound() => _soundAndMusic.ChangeSound();

    public void CahngeMusic() => _soundAndMusic.ChangeMusic();

    public void ChangeLanguage() => _language.ChangeLanguage();

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
        _soundValueText.text = _soundAndMusic.SoundVolume > 0f ? _language.GetTranslate("On") : _language.GetTranslate("Off");
        _musicValueText.text = _soundAndMusic.MusciVolume > 0f ? _language.GetTranslate("On") : _language.GetTranslate("Off");

        _languageValueText.text = _language.GetTranslate(_language.CurrentLanguage.ToString());
    }
}
