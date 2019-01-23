using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : UnitMovement
{

    public void Rotate(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
        Direction.Value = transform.up;
    }
    
}
