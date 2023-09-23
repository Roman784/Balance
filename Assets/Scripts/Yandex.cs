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
}
