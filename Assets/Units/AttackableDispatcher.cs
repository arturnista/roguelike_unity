using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableDispatcher : Attackable
{

    public DamageEvent Event;

    public override void DealDamage(float damage, RaycastHit2D hit, Transform damager) 
    {
        base.DealDamage(damage, hit, damager);
        Event.Damage = damage;
        Event.Hit = hit;
        Event.Damager = damager;
        Event.Dispatch();
    }
    
}
