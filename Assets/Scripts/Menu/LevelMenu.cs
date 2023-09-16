using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    private void Start()
    {
        DeathZone.PlayerDetected.AddListener(RestartLevel);
    }

    private void RestartLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    
}
