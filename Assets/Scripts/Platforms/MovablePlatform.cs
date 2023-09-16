using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    [SerializeField] private Transform _platform;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Transform[] _points;
    private int _currentPointIndex;

    private void Update()
    {
        _platform.position = Vector3.MoveTowards(_platform.position, _points[_currentPointIndex].position, _movementSpeed * Time.deltaTime);

        if (_platform.position == _points[_currentPointIndex].position) _currentPointIndex += 1;

        if (_currentPointIndex >= _points.Length) _currentPointIndex = 0;
    }
}
