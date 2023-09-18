using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControl : MovementControl
{
    [SerializeField] private JoystickCanvas _canvas;
    private Joystick _joystick;

    private void Start()
    {
        if (CurrentDevicePlatform.Get() != DevicePlatforms.Android) return;

        JoystickCanvas canvas = Instantiate(_canvas);
        _joystick = canvas.GetJoystick();
    }

    public override Vector3 GetDirection()
    {
        return new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
    }

    public override bool IsMoving()
    {
        return (_joystick.Horizontal != 0f || _joystick.Vertical != 0f);
    }
}
