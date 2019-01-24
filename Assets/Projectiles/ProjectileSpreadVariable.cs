using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ProjectileSpreadVariable : MonoBehaviour
{
        
    [Header("Configuration")]
    [Header("Movement")]
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
        Direction = ScriptableObject.Instantiate(Direction);
        Velocity = ScriptableObject.Instantiate(Velocity);

        ProjectileMovement movement = GetComponent<ProjectileMovement>();
        movement.Direction.InstanceVariable = Direction;
        movement.Velocity.InstanceVariable = Velocity;

        ProjectileDamage damage = GetComponent<ProjectileDamage>();
        damage.Damage.InstanceVariable = Damage;

    }

}