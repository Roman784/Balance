using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Puase : MonoBehaviour
{
    [SerializeField] private LevelMenu _menu;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;

        _animator.SetTrigger("Pause");
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f;

        _animator.SetTrigger("Continue");
    }

    public void GoToMainMenu()
    {
        _menu.GoToMainMenu();
    }
}
