using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    private int _number;
    [SerializeField] private TMP_Text _numberText;

    [Space]

    [SerializeField] private GameObject _video;
    [SerializeField] private GameObject _lock;
    private bool _isLock;
    private bool _isAllowOpeningForVideo;

    private MainMenu _menu;

    private void Awake()
    {
        _isLock = true;
        _isAllowOpeningForVideo = false;

        _video.SetActive(false);
    }

    public void Setup(MainMenu menu, int number)
    {
        _menu = menu;

        _number = number;
        _numberText.text = _number.ToString();
    }

    public void Unlock()
    {
        _isAllowOpeningForVideo = false;
        _isLock = false;
        _lock.SetActive(false);
        _video.SetActive(false);
    }

    public void OnClick()
    {
        if (_isAllowOpeningForVideo && Yandex.Instance.IsAdOpen == false)
        {
            Yandex.Instance.ShowRewardedVideo();
            return;
        }

        if (_isLock) return;

        _menu.GoToLevel(_number);
    }

    public void AllowOpeningForVideo()
    {
        _isAllowOpeningForVideo = true;
        _lock.SetActive(false);
        _video.SetActive(true);
    }
}
