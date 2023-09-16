using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : Menu
{
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
