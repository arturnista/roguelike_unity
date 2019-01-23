using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UnitMovement : MonoBehaviour
{

#region Configuration
    [Header("Configuration")]
    [SerializeField]
    public FloatReference Acceleration;
    [SerializeField]
    public FloatReference MoveSpeed;
#endregion

#region Variables
    [Header("Variables")]
    [SerializeField]
    public Vector2Reference Direction;
    [SerializeField]
    public Vector2Reference Velocity;
    [SerializeField]
    public Vector2Reference DesirableVelocity;
    [SerializeField]
    public BoolReference UnableToMove;
#endregion

    protected Rigidbody2D rigidbody;

    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        
        if(!UnableToMove.Value) DesirableVelocity.Value = Direction.Normalized * MoveSpeed.Value;
        else DesirableVelocity.Value = Vector2.zero;

        Vector2 velocity = Velocity.Value;
        velocity = Vector2.MoveTowards(velocity, DesirableVelocity.Value, Acceleration.Value * Time.deltaTime);
        Velocity.Value = velocity;

    }

    protected virtual void FixedUpdate()
    {
        rigidbody.velocity = Velocity.Value;
        // rigidbody.MovePosition(transform.position + (Vector3)(Velocity.Value * Time.fixedDeltaTime));
    }


}
