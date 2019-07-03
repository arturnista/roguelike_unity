using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInventory", menuName = "Player/Create Inventory")]
public class PlayerInventory : ScriptableObject
{
    
    public bool Reset;

    public SwordData CurrentSword;
    public ShieldData CurrentShield;
    public List<ItemKey> Keys = new List<ItemKey>();

    void OnEnable()
    {
        if (Reset)
        {
            Keys = new List<ItemKey>();
        }
    }

}
