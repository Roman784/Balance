using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class Repository : MonoBehaviour
{
    public static Repository Instance;

    [SerializeField] private GameData _gameData;
    public GameData GameData { get { return _gameData; } private set { _gameData = value; } }

    [Space]

    [SerializeField] private GameData _defaultData;

    [Space]

    [SerializeField] private string _saveFileName;
    private string _savePath;

    public static UnityEvent DataLoaded = new UnityEvent();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);

        if (CurrentDevicePlatform.Get() == DevicePlatforms.Android) _savePath = Path.Combine(Application.persistentDataPath, _saveFileName);
        else _savePath = Path.Combine(Application.dataPath, _saveFileName);
    }

    /*private void Start()
    {
        LoadData();
    }*/

    private void SaveData()
    {
        try
        {
            string json = JsonUtility.ToJson(GameData, true);
            Yandex.Instance.SaveData(json);

            Debug.Log("Save data complete");
        }
        catch { Debug.Log("Save data error"); }
    }

    public void LoadData(string data)
    {
        try
        {
            GameData = JsonUtility.FromJson<GameData>(data);

            if (data == "{}")
            {
                DefaultData();
                Debug.Log("Starting data");
            }

            Debug.Log("Load data complete");
        }
        catch { Debug.Log("Load data error"); }

        DataLoaded.Invoke();
    }

    public void ResetlData()
    {
        DefaultData();
        SaveData();
    }

    private void DefaultData()
    {
        GameData.SoundVolume = _defaultData.SoundVolume;
        GameData.MusicVolume = _defaultData.MusicVolume;
        GameData.Language = Yandex.Instance.GetLang();
        GameData.LastPassedLevel = _defaultData.LastPassedLevel;
    }

    public void SetSoundVolume(float value)
    {
        _gameData.SoundVolume = value;
        SaveData();
    }

    public void SetMusicVolume(float value)
    {
        _gameData.MusicVolume = value;
        SaveData();
    }

    public void SetLanguage(Languages value)
    {
        _gameData.Language = value;
        SaveData();
    }

    public void SetLastPassedLevel(int value)
    {
        if (value <= _gameData.LastPassedLevel) return;

        _gameData.LastPassedLevel = value;
        SaveData();
    }

    public void OpenNextLevel()
    {
        GameData.LastPassedLevel += 1;
        SaveData();
    }
}
