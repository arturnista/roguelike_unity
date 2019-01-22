using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

#region Configuration
    [Header("Configuration")]
    [SerializeField]
    protected FloatReference MaxHealth;
#endregion

#region Variables
    [Header("Variables")]
    [SerializeField]
    protected FloatReference Health;
    [SerializeField]
    protected FloatReference Resistence;
#endregion

    public virtual void GiveHealth(float health)
    {
        Health.Value += health;
        if(Health.Value > MaxHealth.Value) Health.Value = MaxHealth.Value;
    }

    public virtual void DealDamage(float damage) 
    {
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
