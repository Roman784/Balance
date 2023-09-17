using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : Menu
{
    [SerializeField] private GameObject _clearDataConfirm;

    public void ChangeSound()
    {

    }

    public void CahngeMusic()
    {

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
}
