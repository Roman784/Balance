using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    private int _number;
    [SerializeField] private TMP_Text _numberText;

    [Space]

    [SerializeField] private GameObject _lock;
    private bool _isLock;

    private MainMenu _menu;

    private void Awake()
    {
        _isLock = true;
    }

    public void Setup(MainMenu menu, int number)
    {
        _menu = menu;

        _number = number;
        _numberText.text = _number.ToString();
    }

    public void Unlock()
    {
        _isLock = false;
        _lock.SetActive(false);
    }

    public void OnClick()
    {
        if (_isLock) return;

        _menu.GoToLevel(_number);
    }
}
