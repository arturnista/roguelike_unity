using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ProjectileSpreadVariable : MonoBehaviour
{
        
    [Header("Configuration")]
    [Header("Movement")]
    [SerializeField]
    protected FloatVariable MoveSpeed;
    [SerializeField]
    protected FloatVariable Damage;

    [Header("Variables")]
    [SerializeField]
    public Vector2Variable Direction;
    [SerializeField]
    protected Vector2Variable Velocity;

    void Awake()
    {
        Damage = ScriptableObject.Instantiate(Damage);
        MoveSpeed = ScriptableObject.Instantiate(MoveSpeed);
        Direction = ScriptableObject.Instantiate(Direction);
        Velocity = ScriptableObject.Instantiate(Velocity);

        ProjectileMovement movement = GetComponent<ProjectileMovement>();
        movement.MoveSpeed.InstanceVariable = MoveSpeed;
        movement.Direction.InstanceVariable = Direction;
        movement.Velocity.InstanceVariable = Velocity;

        ProjectileDamage damage = GetComponent<ProjectileDamage>();
        damage.Damage.InstanceVariable = Damage;

    }

}