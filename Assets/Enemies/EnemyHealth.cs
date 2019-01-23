using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Destructible
{

    [SerializeField]
    public Vector2Reference Velocity;

    public override void DealDamage(float damage, RaycastHit2D hit) {
        base.DealDamage(damage, hit);

        Velocity.Value += -hit.normal * damage;
    }

}
