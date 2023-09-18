using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu
{
    [Space]

    [SerializeField] private LevelButton _levelButtonPrefab;
    [SerializeField] private Transform _levelsGridContent;

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
            if (levelNumber <= Repository.Instance.GameData.LastPassedLevel + 1) spawnedButton.Unlock();
        }
    }

    public void GoToLevel(int number) => OpenScene(_levels.Names[number - 1]);

    public void GoToSettingMenu() => OpenScene("SettingsMenu");
}
