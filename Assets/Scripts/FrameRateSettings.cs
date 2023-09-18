using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateSettings : MonoBehaviour
{
    public static FrameRateSettings Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);

        Application.targetFrameRate = 500;
    }
}
