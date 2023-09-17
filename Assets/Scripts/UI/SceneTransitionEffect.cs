using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SceneTransitionEffect : MonoBehaviour
{
    public static SceneTransitionEffect Instance { get; private set; }

    [SerializeField] private AnimationClip _disappearanceClip;

    private Animator _animator;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;

        _animator = GetComponent<Animator>();
    }

    public float PlayDisapperanceAnimation ()
    {
        _animator.SetTrigger("Disappearance");

        return _disappearanceClip.length;
    }
}
