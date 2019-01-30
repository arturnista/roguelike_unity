using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SwordData", menuName = "Player/Weapons/Create Sword")]
public class SwordData : ScriptableObject
{

    [SerializeField]
    public string Name;
    [Multiline]
    [SerializeField]
    public string Description;
    [SerializeField]
    public float Damage;
    [SerializeField]
    public float AttackRange;
    [SerializeField]
    public float Cooldown;

    [SerializeField]
    [ReadOnly]
    private float currentCooldown;
    public float CurrentCooldown
    {
        get
        {
            return currentCooldown;
        }

        set
        {
            currentCooldown = value;
        }
    }

    public bool CanAttack() {
        return currentCooldown < 0f;
    }

    public void Attack() {
        currentCooldown = Cooldown;
    }

}
