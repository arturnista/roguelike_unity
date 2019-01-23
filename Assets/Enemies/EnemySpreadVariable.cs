using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemySpreadVariable : MonoBehaviour
{
        
    [Header("Configuration")]
    [Header("Movement")]

    [Header("Variables")]
    [SerializeField]
    protected Vector2Variable Direction;
    [SerializeField]
    protected Vector2Variable Velocity;
    [SerializeField]
    protected Vector2Variable DesirableVelocity;
    [SerializeField]
    protected BoolVariable UnableToMove;

    [Header("Configuration")]
    [Header("Health")]

    [Header("Variables")]
    [SerializeField]
    protected FloatVariable Health;
    [SerializeField]
    protected FloatVariable Resistence;

    [Header("Configuration")]
    [Header("Attack")]
    [SerializeField]
    protected FloatVariable AttackDelay;

    [Header("Variables")]
    [SerializeField]
    protected TransformVariable Target;

    void Awake()
    {
        Direction = ScriptableObject.Instantiate(Direction);
        Velocity = ScriptableObject.Instantiate(Velocity);
        DesirableVelocity = ScriptableObject.Instantiate(DesirableVelocity);
        UnableToMove = ScriptableObject.Instantiate(UnableToMove);

        Health = ScriptableObject.Instantiate(Health);
        Resistence = ScriptableObject.Instantiate(Resistence);
        
        AttackDelay = ScriptableObject.Instantiate(AttackDelay);
        Target = ScriptableObject.Instantiate(Target);

        EnemyMovement movement = GetComponent<EnemyMovement>();
        EnemyHealth health = GetComponent<EnemyHealth>();
        EnemyAttack attack = GetComponent<EnemyAttack>();
        EnemyTargetDetector target = GetComponentInChildren<EnemyTargetDetector>();

        movement.Direction.InstanceVariable = Direction;
        movement.Velocity.InstanceVariable = Velocity;
        movement.DesirableVelocity.InstanceVariable = DesirableVelocity;
        movement.UnableToMove.InstanceVariable = UnableToMove;
        movement.Target.InstanceVariable = Target;

        health.Health.InstanceVariable = Health;
        health.Resistence.InstanceVariable = Resistence;
        health.Velocity.InstanceVariable = Velocity;
        health.Target.InstanceVariable = Target;
        health.AttackDelay.InstanceVariable = AttackDelay;

        attack.Target.InstanceVariable = Target;
        attack.AttackDelay.InstanceVariable = AttackDelay;

        target.Target.InstanceVariable = Target;
    }

}