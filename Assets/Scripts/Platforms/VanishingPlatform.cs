using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class VanishingPlatform : MonoBehaviour
{
    [SerializeField] private float _timeBeforVanish; // Небольшая задержка, перед тем как исчезнуть.
    [SerializeField] private float _cooldown;
    private bool _canVanish;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _canVanish = true;
    }

    private IEnumerator Vanish()
    {
        _canVanish = false;

        yield return new WaitForSeconds(_timeBeforVanish);

        _animator.SetTrigger("Vanish");

        yield return new WaitForSeconds(_cooldown);

        _canVanish = true;
        _animator.SetTrigger("Appear");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && _canVanish)
            StartCoroutine(Vanish());
    }
}
