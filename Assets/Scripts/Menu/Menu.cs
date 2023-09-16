using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] protected Levels _levels;
    protected int _currentLevelIndex;

    private void Awake()
    {
        _currentLevelIndex = _levels.Names.IndexOf(SceneManager.GetActiveScene().name);
    }

    protected void OpenScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
