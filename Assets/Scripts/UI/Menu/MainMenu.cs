using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu
{
    [SerializeField] private int _lastOpenLevel;

    [Space]

    [SerializeField] private LevelButton _levelButtonPrefab;
    [SerializeField] private Transform _levelsGridContent;

    private void Start()
    {
        for (int i = 0; i < _levels.Names.Count; i++)
        {
            LevelButton spawnedButton = Instantiate(_levelButtonPrefab);
            spawnedButton.transform.SetParent(_levelsGridContent);
            spawnedButton.transform.localScale = new Vector3(1f, 1f, 1f);

            int levelNumber = i + 1;

            spawnedButton.Setup(this, levelNumber);
            if (levelNumber - 1 <= _lastOpenLevel) spawnedButton.Unlock();
        }
    }

    public void GoToLevel(int number) => OpenScene(_levels.Names[number - 1]);

    public void GoToSettingMenu() => OpenScene("SettingsMenu");
}
