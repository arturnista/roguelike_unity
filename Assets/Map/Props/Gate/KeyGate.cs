using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGate : Gate
{
    
    public ItemKey RequiredKey;
    public PlayerInventory Inventory;

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer.color = RequiredKey.Color;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.transform.GetComponent<PlayerMovement>();
        if(player)
        {
            if(Inventory.Keys.Contains(RequiredKey))
            {
                Open();
                Inventory.Keys.Remove(RequiredKey);
            }
        }
    }

}
