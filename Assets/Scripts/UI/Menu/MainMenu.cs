using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu
{
    [Space]

    [SerializeField] private LevelButton _levelButtonPrefab;
    [SerializeField] private Transform _levelsGridContent;

    private List<LevelButton> _spawnedButtons = new List<LevelButton>();

    private void Awake()
    {
        Repository.DataLoaded.AddListener(LoadLevels);
    }

    private void LoadLevels()
    {
        for (int levelNumber = 1; levelNumber <= _levels.Names.Count; levelNumber++)
        {
            LevelButton spawnedButton = Instantiate(_levelButtonPrefab);
            spawnedButton.transform.SetParent(_levelsGridContent);
            spawnedButton.transform.localScale = new Vector3(1f, 1f, 1f);

            spawnedButton.Setup(this, levelNumber);

            int index = Repository.Instance.GameData.LastPassedLevel;
            if (levelNumber <= index + 1) spawnedButton.Unlock();

            if (levelNumber == index + 2) spawnedButton.AllowOpeningForVideo();

            _spawnedButtons.Add(spawnedButton);
        }
    }

    public void GoToLevel(int number) => OpenScene(_levels.Names[number - 1]);

    public void GoToSettingMenu() => OpenScene("SettingsMenu");

    public void OpenNextLevel()
    {
        Repository.Instance.OpenNextLevel();

        int index = Repository.Instance.GameData.LastPassedLevel;

        if (index < _spawnedButtons.Count) _spawnedButtons[index].Unlock();
        if (index + 1 < _spawnedButtons.Count) _spawnedButtons[index + 1].AllowOpeningForVideo();
    }
}
