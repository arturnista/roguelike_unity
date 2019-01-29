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
    protected LayerMaskReference AttackLayer;
#endregion

#region Variables
    [Header("Variables")]
    [SerializeField]
    protected BoolReference UnableToMove;
    [SerializeField]
    protected Vector2Reference LookDirection;
    [SerializeField]
    protected Vector2Reference Velocity;
#endregion

#region Effects
    [Header("Effects")]
    [SerializeField]
    private GameObject AttackEffect;
#endregion

    private bool canAttack = true;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Attack();
        }
        Holder.CurrentSword.CurrentCooldown -= Time.deltaTime;
    }

    public void Attack() {
        if(!canAttack) return;
        
        Velocity.Value += LookDirection.Value * 10f;

        if(AttackEffect) {
            float angle = Mathf.Atan2(LookDirection.Value.y, LookDirection.Value.x) * Mathf.Rad2Deg;
            Instantiate(AttackEffect, transform.position + (Vector3)LookDirection.Value, Quaternion.Euler(0f, 0f, angle - 90)).transform.parent = transform;
        }

        float attackRadius = 0.5f;
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, attackRadius, LookDirection.Value, (Holder.CurrentSword.AttackRange * 1.5f) - attackRadius, AttackLayer.Value);
        if(hits.Length > 0) {
            foreach(RaycastHit2D hit in hits) {
                Destructible hitDestructible = hit.transform.GetComponent<Destructible>();
                if(hitDestructible != null) {
                    hitDestructible.DealDamage(Holder.CurrentSword.Damage, hit, transform);
                }
            }
        }

        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown() {
        
        canAttack = false;
        UnableToMove.Value = true;
        yield return new WaitForSeconds(Holder.CurrentSword.Cooldown);

        canAttack = true;
        UnableToMove.Value = false;
        yield return null;
    }

}
