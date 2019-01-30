using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInventory", menuName = "Player/Create Inventory")]
public class PlayerInventory : ScriptableObject
{
    
    public SwordData CurrentSword;
    public ShieldData CurrentShield;

}
