using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShieldData", menuName = "Player/Shields/Create Shield")]
public class ShieldData : ScriptableObject
{

    [SerializeField]
    public string Name;
    [Multiline]
    [SerializeField]
    public string Description;
    [SerializeField]
    [Range(0f, 2f)]
    public float MoveSpeedMultiplier = 1f;
    [SerializeField]
    [Range(0f, 1f)]
    public float DamageKnockbackReceive = 0f;
    public float DamageMultiplier { get { return 1 - DamageKnockbackReceive; } }

}
