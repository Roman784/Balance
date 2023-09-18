using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : Menu
{
    private int _currentLevelIndex;

    private void Awake()
    {
        _currentLevelIndex = _levels.Names.IndexOf(SceneManager.GetActiveScene().name);

        Finish.PlayerDetected.AddListener(GoToNextLevel);
        DeathZone.PlayerDetected.AddListener(RestartLevel);
    }

    private void GoToNextLevel()
    {
        Repository.Instance.SetLastPassedLevel(_currentLevelIndex + 1);

        _currentLevelIndex += 1;
        if (_currentLevelIndex >= _levels.Names.Count)
        {
            GoToMainMenu();
            return;
        }

        OpenScene(_levels.Names[_currentLevelIndex]);
    }

    private void RestartLevel () => OpenScene(_levels.Names[_currentLevelIndex]);  
}
