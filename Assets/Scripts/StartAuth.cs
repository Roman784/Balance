using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAuth : MonoBehaviour
{
    [DllImport("__Internal")] private static extern void InitExtern();

    private void Start()
    {
        InitExtern();
    }

    public void GoToBootstrap()
    {
        SceneManager.LoadScene("Bootstrap");
    }
}
