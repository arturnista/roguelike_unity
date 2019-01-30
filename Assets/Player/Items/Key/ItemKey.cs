using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemKey", menuName = "Player/Items/Key")]
public class ItemKey : ScriptableObject
{

    [SerializeField]
    public string Name;
    [Multiline]
    [SerializeField]
    public string Description;
    [SerializeField]
    public Sprite Sprite;
    [SerializeField]
    public Color Color;

}
