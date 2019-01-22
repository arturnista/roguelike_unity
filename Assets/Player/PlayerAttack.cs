using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

#region Configuration
    [Header("Configuration")]
    [SerializeField]
    protected PlayerWeaponsHolder Holder;
    [SerializeField]
    protected LayerMask AttackLayer;
#endregion

#region Variables
    [Header("Variables")]
    [SerializeField]
    protected Vector2Reference LookDirection;
    [SerializeField]
    protected Vector2Reference Velocity;
#endregion

#region Effects
    [Header("Effects")]
    [SerializeField]
    private GameObject ImpactEffect;
#endregion

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Attack();
        }
        Holder.CurrentSword.CurrentCooldown -= Time.deltaTime;
    }

    public void Attack() {
        if(!Holder.CurrentSword.CanAttack()) return;
        Holder.CurrentSword.Attack();
        
        Velocity.Value += LookDirection.Value * 5f;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, LookDirection.Value, Holder.CurrentSword.AttackRange, AttackLayer);
        if(hits.Length > 0) {
            foreach(RaycastHit2D hit in hits) {
                Destructible hitDestructible = hit.transform.GetComponent<Destructible>();
                if(hitDestructible != null) {
                    hitDestructible.DealDamage(Holder.CurrentSword.Damage);
                    if(ImpactEffect) Instantiate(ImpactEffect, hit.point, Quaternion.identity);
                }
            }
        }
    }

}
