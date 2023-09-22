using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaling : MonoBehaviour
{
    [SerializeField] private Vector2 _resolution;

    [Space]

    [SerializeField] private float _baseSize;
    [SerializeField] private float _minSize;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        float screenHeight = Screen.height; // Y.
        float screenWidth = Screen.width;   // X.

        float size = (int)(_baseSize * (_resolution.x / _resolution.y) / (screenWidth / screenHeight));
        if (size < _minSize) size = _minSize;

        _camera.orthographicSize = size;
    }
}
