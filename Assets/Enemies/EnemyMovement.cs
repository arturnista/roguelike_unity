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
    [SerializeField]
    public LayerMaskReference ObstacleLayer;
#endregion

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private Vector3 offsetPosition;

    private Coroutine changeDirectionCoroutine;

    protected override void Awake()
    {
        base.Awake();

        originalPosition = transform.position;
        MoveSpeed.Value *= .3f;

        changeDirectionCoroutine = StartCoroutine(ChangeDirection());
    }

    void OnEnable()
    {
        Target.OnChangeValue += OnChangeTarget;        
    }

    void OnDisable()
    {
        Target.OnChangeValue -= OnChangeTarget;        
    }

    protected override void Update()
    {
        base.Update();

        Vector3 referencePosition;

        if(Target.Value)
        {
            referencePosition = Target.Value.position;
        }
        else
        {
            referencePosition = originalPosition;
        }

        Vector2 targetDirection = (referencePosition + offsetPosition) - transform.position;
        Direction.Value = targetDirection.normalized;
    }

    IEnumerator ChangeDirection()
    {
        while (true)
        {
            offsetPosition = (Vector3)Random.insideUnitCircle.normalized * 10f;
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    IEnumerator ChangeTargetPosition()
    {
        while (true)
        {
            offsetPosition = (Vector3)Random.insideUnitCircle.normalized * 5f;
            yield return new WaitForSeconds(Random.Range(8f, 12f));
        }
    }

    void OnChangeTarget(Transform oldTarget)
    {
        if(oldTarget == null)
        {
            StopCoroutine(changeDirectionCoroutine);
            StartCoroutine(ChangeTargetPosition());
        }

        MoveSpeed.ResetValue();
    }
    
}
