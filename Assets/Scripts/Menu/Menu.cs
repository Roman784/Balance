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
        // Проигрываем анимацию перехода и открываем нужную сцену.
        float delay = SceneTransitionEffect.Instance.PlayDisapperanceAnimation();
        StartCoroutine(OpenSceneWithDelay(name, delay));
    }

    private IEnumerator OpenSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName);
    }

    public void GoToMainMenu()
    {
        OpenScene("MainMenu");
    }
}
