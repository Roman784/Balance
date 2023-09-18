using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickCanvas : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    public Joystick GetJoystick() => _joystick;
}
