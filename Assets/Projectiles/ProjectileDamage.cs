using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{

#region Configuration
    [Header("Configuration")]
    [SerializeField]
    public FloatReference Damage;
#endregion

    private Destructible destructible;
    private Transform creator;
    public Transform Creator
    {
        get { return creator; }
        set { creator = value; }
    }

    void Awake()
    {
        destructible = GetComponent<Destructible>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        Destructible target = collider.GetComponent<Destructible>();    
        if(target)
        {
            RaycastHit2D hit = Physics2D.Linecast(transform.position, target.transform.position);
            target.DealDamage(Damage.Value, hit, creator);
        }
        
        destructible.DestroyObject();

    }

}
