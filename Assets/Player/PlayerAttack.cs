using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

#region Configuration
    [Header("Configuration")]
    [SerializeField]
    protected PlayerInventory Inventory;
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
        Inventory.CurrentSword.CurrentCooldown -= Time.deltaTime;
    }

    public void Attack() {
        if(Inventory.CurrentShield == null) return;
        if(!canAttack) return;
        
        Velocity.Value += LookDirection.Value * 10f;

        if(AttackEffect) {
            float angle = Mathf.Atan2(LookDirection.Value.y, LookDirection.Value.x) * Mathf.Rad2Deg;
            Instantiate(AttackEffect, transform.position + (Vector3)LookDirection.Value, Quaternion.Euler(0f, 0f, angle - 90)).transform.parent = transform;
        }

        float attackRadius = 0.5f;
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, attackRadius, LookDirection.Value, (Inventory.CurrentSword.AttackRange * 1.5f) - attackRadius, AttackLayer.Value);
        if(hits.Length > 0) {
            foreach(RaycastHit2D hit in hits) {
                Attackable hitAttackable = hit.transform.GetComponent<Attackable>();
                if(hitAttackable != null) {
                    hitAttackable.DealDamage(Inventory.CurrentSword.Damage, hit, transform);
                }
            }
        }

        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown() {
        
        canAttack = false;
        UnableToMove.Value = true;
        yield return new WaitForSeconds(Inventory.CurrentSword.Cooldown);

        canAttack = true;
        UnableToMove.Value = false;
        yield return null;
    }

}
