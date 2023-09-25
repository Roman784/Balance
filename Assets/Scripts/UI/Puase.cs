using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Puase : MonoBehaviour
{
    public static Puase Instance;

    [SerializeField] private LevelMenu _menu;
    private bool _isPause;

    private Animator _animator;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            if (_isPause) ContinueGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        AudioListener.volume = 0f;
        Time.timeScale = 0f;
        _isPause = true;

        _animator.SetTrigger("Pause");
    }

    public void ContinueGame()
    {
        AudioListener.volume = 1f;
        Time.timeScale = 1f;
        _isPause = false;

        _animator.SetTrigger("Continue");
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        _menu.GoToMainMenu();
    }
}
