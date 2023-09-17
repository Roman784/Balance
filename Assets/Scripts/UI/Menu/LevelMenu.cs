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
    }

    private void Start()
    {
        Finish.PlayerDetected.AddListener(GoToNextLevel);
        DeathZone.PlayerDetected.AddListener(RestartLevel);
    }

    private void GoToNextLevel()
    {
        _currentLevelIndex += 1;
        if (_currentLevelIndex >= _levels.Names.Count) _currentLevelIndex = 0;

        OpenScene(_levels.Names[_currentLevelIndex]);
    }

    private void RestartLevel ()
    {
        OpenScene(_levels.Names[_currentLevelIndex]);
    }    
}
