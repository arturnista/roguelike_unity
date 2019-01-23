using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemySpreadVariable : SpreadVariable
{
    
    [Header("Configuration")]
    [Header("Movement")]
    [SerializeField]
    protected FloatVariable Acceleration;
    [SerializeField]
    protected FloatVariable MoveSpeed;

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
    [SerializeField]
    protected FloatVariable MaxHealth;

    [Header("Variables")]
    [SerializeField]
    protected FloatVariable Health;
    [SerializeField]
    protected FloatVariable Resistence;

    void Awake()
    {
        Acceleration = ScriptableObject.Instantiate(Acceleration);
        MoveSpeed = ScriptableObject.Instantiate(MoveSpeed);
        Direction = ScriptableObject.Instantiate(Direction);
        Velocity = ScriptableObject.Instantiate(Velocity);
        DesirableVelocity = ScriptableObject.Instantiate(DesirableVelocity);
        UnableToMove = ScriptableObject.Instantiate(UnableToMove);

        MaxHealth = ScriptableObject.Instantiate(MaxHealth);
        Health = ScriptableObject.Instantiate(Health);
        Resistence = ScriptableObject.Instantiate(Resistence);

        EnemyMovement movement = GetComponent<EnemyMovement>();
        EnemyHealth health = GetComponent<EnemyHealth>();

        movement.Acceleration.InstanceVariable = Acceleration;
        movement.MoveSpeed.InstanceVariable = MoveSpeed;
        movement.Direction.InstanceVariable = Direction;
        movement.Velocity.InstanceVariable = Velocity;
        movement.DesirableVelocity.InstanceVariable = DesirableVelocity;
        movement.UnableToMove.InstanceVariable = UnableToMove;

        health.MaxHealth.InstanceVariable = MaxHealth;
        health.Health.InstanceVariable = Health;
        health.Resistence.InstanceVariable = Resistence;
        health.Velocity.InstanceVariable = Velocity;
    }

}