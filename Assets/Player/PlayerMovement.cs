using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : UnitMovement
{

    protected override void Update()
    {

        base.Update();

        float vertical = 0f;
        if(Input.GetKey(KeyCode.W)) 
        {
            vertical = 1f;
        }
        else if(Input.GetKey(KeyCode.S)) 
        {
            vertical = -1f;
        }

        float horizontal = 0f;
        if(Input.GetKey(KeyCode.D))
        {
            horizontal = 1f;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            horizontal = -1f;
        }

        Direction.Value = new Vector2(horizontal, vertical);

    }

}
