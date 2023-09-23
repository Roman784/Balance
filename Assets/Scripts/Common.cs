using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common : MonoBehaviour
{
    public static Common Instance;

    private void Awake()
    {
        /*if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);*/
    }

    private void Start()
    {
        Repository.DataLoaded.Invoke();

        Yandex.Instance.ShowFullscreenAdv();
    }
}
