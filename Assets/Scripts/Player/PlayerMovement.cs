using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _accelirationForce; // Отвечает за силу ускорения и торможения.
    private Vector3 _movementVector; // Основной, отвечающий за движение вектор.

    [Space]

    [SerializeField] private ComputerControl _computerControl;
    [SerializeField] private MobileControl _mobileControl;
    private MovementControl _currentControl;

    [Space]

    [SerializeField] private float _gravity;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Physics.gravity = new Vector3(0f, -_gravity, 0f);

        if (CurrentDevicePlatform.Get() == DevicePlatforms.Android) _currentControl = _mobileControl;
        else _currentControl = _computerControl;
    }

    private void Update()
    {
        NormalizeMovementVector();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _movementVector.y = _rigidbody.velocity.y;
        _rigidbody.velocity = _movementVector;
    }

    // Приводит вектор движения к нужному направлению.
    // Необходим для эффекта ускорения, торможения и заносов.
    private void NormalizeMovementVector()
    {
        _movementVector = Vector3.Lerp(_movementVector, _currentControl.GetDirection() * _speed * Time.fixedDeltaTime, _accelirationForce * Time.deltaTime);
    }

    public bool IsMoving() => _currentControl.IsMoving();
}
