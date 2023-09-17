using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Puase : MonoBehaviour
{
    [SerializeField] private LevelMenu _menu;
    private bool _isPause;

    private Animator _animator;

    private void Awake()
    {
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
        Time.timeScale = 0f;
        _isPause = true;

        _animator.SetTrigger("Pause");
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        _isPause = false;

        _animator.SetTrigger("Continue");
    }

    public void GoToMainMenu()
    {
        _menu.GoToMainMenu();
    }
}
