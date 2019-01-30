using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooterAttack : EnemyAttack
{

    [SerializeField]
    private Vector2Reference AttackDirection;

    public override void Update()
    {   
        AttackDelay.Value -= Time.deltaTime;
        if(AttackDelay.Value < 0f)
        {
            AttackDelay.ResetValue();
            Attack(-AttackDirection.Value);
        }
    }

}
