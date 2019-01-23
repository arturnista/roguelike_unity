using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

#region Configuration
    [Header("Configuration")]
    [SerializeField]
    public FloatReference MaxHealth;
    public bool StartWithMaxHealth;
#endregion

#region Variables
    [Header("Variables")]
    [SerializeField]
    public FloatReference Health;
    [SerializeField]
    public FloatReference Resistence;
    [SerializeField]
    public Vector2Reference Velocity;
#endregion

#region Effects
    [Header("Effects")]
    [SerializeField]
    private GameObject ImpactEffect;
#endregion

    void Start()
    {
        if(StartWithMaxHealth) Health.Value = MaxHealth.Value;
    }

    public virtual void GiveHealth(float health)
    {
        Health.Value += health;
        if(Health.Value > MaxHealth.Value) Health.Value = MaxHealth.Value;
    }

    public virtual void DealDamage(float damage, RaycastHit2D hit, Transform damager) 
    {
        if(ImpactEffect) Instantiate(ImpactEffect, hit.point, Quaternion.identity);
        if(Velocity) Velocity.Value += -hit.normal * damage;

        float fullDamage = damage * Resistence.Value;
        Health.Value -= fullDamage;
        if(Health.Value < 0f) 
        {
            DestroyObject();
        }
    }

    public virtual void DestroyObject() 
    {
        Destroy(this.gameObject);
    }

}
