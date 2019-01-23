using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Destructible
{

    [Header("Enemy")]
    [SerializeField]
    public TransformReference Target;
    [SerializeField]
    public FloatReference AttackDelay;

    public override void DealDamage(float damage, RaycastHit2D hit, Transform damager) {
        base.DealDamage(damage, hit, damager);
        Target.Value = damager;
        AttackDelay.ResetValue();
    }

}
