using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : UnitMovement
{
    
#region Variables
    [Header("Enemy")]
    [SerializeField]
    public TransformReference Target;
    [SerializeField]
    public FloatReference AttackRange;
#endregion

    protected override void Update()
    {
        base.Update();

        Direction.Value = Vector2.zero;
        if(Target.Value)
        {
            float distance = Vector2.Distance(Target.Value.position, transform.position);
            if(distance <= AttackRange.Value) return;

            Vector2 targetDirection = Target.Value.position - transform.position;
            Direction.Value = targetDirection.normalized;
        }
    }
    
}
