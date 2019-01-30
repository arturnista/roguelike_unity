using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDKeyDisplay : MonoBehaviour
{

    public PlayerInventory Inventory;
    public GameObject HudKeyPrefab;

    private int lastCount = 0;

    void Start()
    {
        lastCount = Inventory.Keys.Count;
    }

    void Update()
    {
        if(lastCount != Inventory.Keys.Count)
        {
            lastCount = Inventory.Keys.Count;

            for (int i = transform.childCount - 1; i >= 0 ; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            foreach (ItemKey key in Inventory.Keys)
            {
                GameObject hudKey = Instantiate(HudKeyPrefab) as GameObject;
                hudKey.transform.SetParent( transform );
                Image image = hudKey.GetComponentInChildren<Image>();
                
                image.sprite = key.Sprite;
                image.color = key.Color;
            }
        }
    }
}
