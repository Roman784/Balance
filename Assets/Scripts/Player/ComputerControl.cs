using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerControl : MovementControl
{
    public override Vector3 GetDirection()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    }

    public override bool IsMoving()
    {
        return (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f);
    }
}
