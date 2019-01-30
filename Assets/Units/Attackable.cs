using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{

#region Effects
    [Header("Effects")]
    [SerializeField]
    private GameObject ImpactEffect;
#endregion

    public virtual void DealDamage(float damage, RaycastHit2D hit, Transform damager) 
    {
        if(ImpactEffect) Instantiate(ImpactEffect, hit.point, Quaternion.identity);
    }
    
}
