using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _accelirationForce; // �������� �� ���� ��������� � ����������.
    private Vector3 _movementVector; // ��������, ���������� �� �������� ������.

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
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

    // �������� ������ �������� � ������� �����������.
    // ��������� ��� ������� ���������, ���������� � �������.
    private void NormalizeMovementVector()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        _movementVector = Vector3.Lerp(_movementVector, direction * _speed * Time.fixedDeltaTime, _accelirationForce * Time.deltaTime);
    }
}
