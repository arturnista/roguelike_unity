using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Events/Damage")]
public class DamageEvent : BaseEvent
{
    
    public float Damage;
    public RaycastHit2D Hit;
    public Transform Damager;

}
