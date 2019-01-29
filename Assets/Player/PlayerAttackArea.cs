using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackArea : MonoBehaviour
{

#region Configuration
    [Header("Configuration")]
    [SerializeField]
    protected Vector2Reference LookDirection;
    [SerializeField]
    protected PlayerWeaponsHolder Holder;
    [SerializeField]
    protected BoolReference IsAttacking;
#endregion

#region Variables
    [Header("Variables")]
    [SerializeField]
    protected List<Destructible> Destructibles;
    // protected ListDestructibleReference Destructibles;
#endregion

    private CapsuleCollider2D collider;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();

        StopAttacking();

        IsAttacking.OnChangeValue += oldValue => {
            if(IsAttacking.Value) StartAttacking();
            else StopAttacking();
        };
    }

    void Update()
    {
        float angle = Mathf.Atan2(LookDirection.Value.y, LookDirection.Value.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);
        transform.localPosition = LookDirection.Value;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destructible destructible = collider.GetComponent<Destructible>();
        if(destructible)
        {
            if(IsAttacking.Value) DealDamageToTarget(destructible);
        }
    }

    void StartAttacking()
    {
        collider.enabled = true;
        spriteRenderer.enabled = true;
        animator.enabled = true;

        for(int i = Destructibles.Count - 1; i >= 0; i--)
        {
            if(Destructibles[i] != null) DealDamageToTarget(Destructibles[i]);
        }
        
        Destructibles.Clear();
    }

    void StopAttacking()
    {
        collider.enabled = false;
        spriteRenderer.enabled = false;
        animator.enabled = false;
    }

    void DealDamageToTarget(Destructible target)
    {
        Debug.Log(target.transform.name);
        Transform player = transform.parent;

        RaycastHit2D hit = Physics2D.Linecast(player.position, target.transform.position);
        target.DealDamage(Holder.CurrentSword.Damage, hit, player);
    
    }

}
