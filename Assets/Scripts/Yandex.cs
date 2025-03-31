using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class Yandex : MonoBehaviour
{
    public static Yandex Instance;

    [DllImport("__Internal")] private static extern void SaveExtern(string date);
    [DllImport("__Internal")] private static extern void LoadExtern();
    [DllImport("__Internal")] private static extern string GetLangExtern();
    [DllImport("__Internal")] private static extern void ShowFullscreenAdvExtern();
    [DllImport("__Internal")] private static extern void ShowRewardedVideoExtern();

    public bool IsAdOpen;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ShowFullscreenAdv();
        LoadExtern();
    }

    public void LoadData(string data)
    {
        Repository.Instance.LoadData(data);

        SceneManager.LoadScene("MainMenu");
    }

    public void SaveData(string data)
    {
        SaveExtern(data);
    }

    public Languages GetLang()
    {
        string lang = GetLangExtern();

        if (lang == "ru") return Languages.Ru;
        return Languages.En;
    }

    public void ShowFullscreenAdv()
    {
        if (IsAdOpen) return;

        ShowFullscreenAdvExtern();
    }

    public void ShowRewardedVideo()
    {
        if (IsAdOpen) return;

        ShowRewardedVideoExtern();
    }
    public void OnRewarded()
    {
        FindObjectOfType<MainMenu>().OpenNextLevel();
    }

    public void AudioVolumeOff()
    {
        IsAdOpen = true;
        AudioListener.volume = 0f;
        Time.timeScale = 0f;
        //Puase.Instance?.PauseGame();
    }
    public void AudioVolumeOn()
    {
        IsAdOpen = false;
        AudioListener.volume = 1f;
        Time.timeScale = 1f;
        // Puase.Instance?.ContinueGame();
    }
}
