using UnityEngine;

public abstract class MovementControl : MonoBehaviour
{
    public abstract Vector3 GetDirection();
    public abstract bool IsMoving();
}