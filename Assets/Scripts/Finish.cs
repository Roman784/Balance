using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    public static UnityEvent PlayerDetected = new UnityEvent();

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
            PlayerDetected.Invoke();
    }
}
