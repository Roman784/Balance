using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathZone : MonoBehaviour
{
    public static UnityEvent PlayerDetected = new UnityEvent();

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
            PlayerDetected.Invoke();

    }
}
