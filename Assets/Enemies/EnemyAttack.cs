using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

#region Configuration
    [Header("Configuration")]
    [SerializeField]
    public FloatReference AttackRange;
    [SerializeField]
    public GameObject ProjectilePrefab;
#endregion

#region Variables
    [Header("Variables")]
    [SerializeField]
    public FloatReference AttackDelay;
    [SerializeField]
    public TransformReference Target;
#endregion

    void Update()
    {   
        if(Target.Value) {

            AttackDelay.Value -= Time.deltaTime;
            if(AttackDelay.Value < 0f)
            {
                AttackDelay.ResetValue();
                Attack();
            }
            
        }
    }
    
    void Attack()
    {
        
        Vector3 attackDirection = (transform.position - Target.Value.position).normalized;
        GameObject projectile = Instantiate(ProjectilePrefab, transform.position - attackDirection, Quaternion.identity) as GameObject;
        ProjectileMovement mov = projectile.GetComponent<ProjectileMovement>();
        mov.Rotate(attackDirection);
        ProjectileDamage damage = projectile.GetComponent<ProjectileDamage>();
        damage.Creator = transform;

    }

}
