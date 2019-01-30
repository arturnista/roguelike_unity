using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKeyObject : MonoBehaviour
{
    
    public ItemKey Key;
    public PlayerInventory Inventory;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(Key != null) Construct(Key);
    }

    public void Construct(ItemKey key)
    {
        Key = key;
        
        spriteRenderer.sprite = Key.Sprite;
        spriteRenderer.color = Key.Color;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Inventory.Keys.Add(Key);
        Destroy(gameObject);
    }

}
