using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlatform : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _direction;

    [Space]

    [SerializeField] private float _pauseDuration;

    private Vector3 _initialRotateAngle;
    private Vector3 _nextRotationAngle;

    private bool _canRotation;

    private void Awake()
    {
        _canRotation = true;

        _initialRotateAngle = transform.eulerAngles;
        _nextRotationAngle = _initialRotateAngle + _direction * 180f;
    }

    private void Update()
    {
        if (_canRotation) transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.Euler(_nextRotationAngle), _speed * Time.deltaTime);

        if (transform.rotation == Quaternion.Euler(_nextRotationAngle))
        {
            transform.rotation = Quaternion.Euler(_initialRotateAngle);

            StartCoroutine(Pause());
        }
    }

    private IEnumerator Pause()
    {
        _canRotation = false;

        yield return new WaitForSeconds(_pauseDuration);

        _canRotation = true;
    }
}
