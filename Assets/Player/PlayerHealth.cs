using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Destructible
{
    
    public override void DestroyObject() {
        Debug.Log("Dead!");
    }

}
