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
    [SerializeField]
    protected BoolReference IsAttacking;
#endregion

    private bool canAttack = true;

    void Awake()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Attack();
        }
        Holder.CurrentSword.CurrentCooldown -= Time.deltaTime;
    }

    public void Attack()
    {
        if(!canAttack) return;
        
        Velocity.Value += LookDirection.Value * 10f;

        StartCoroutine(AttackTime());
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackTime()
    {
        IsAttacking.Value = true;        
        yield return new WaitForSeconds(0.37f);
        IsAttacking.Value = false;
    }

    IEnumerator AttackCooldown()
    {
        
        canAttack = false;
        UnableToMove.Value = true;
        yield return new WaitForSeconds(Holder.CurrentSword.Cooldown);

        canAttack = true;
        UnableToMove.Value = false;
        yield return null;
    }

}
