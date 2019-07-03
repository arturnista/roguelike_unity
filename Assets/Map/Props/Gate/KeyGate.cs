using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGate : Gate, IUsable
{
    
    public ItemKey RequiredKey;
    public PlayerInventory Inventory;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer.color = RequiredKey.Color;
    }

    public bool Use(Transform user)
    {
        PlayerMovement player = user.GetComponent<PlayerMovement>();
        if(player)
        {
            if(Inventory.Keys.Contains(RequiredKey))
            {
                Open();
                Inventory.Keys.Remove(RequiredKey);

                return true;
            }
        }

        return false;
    }

}
