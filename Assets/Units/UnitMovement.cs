using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UnitMovement : MonoBehaviour
{

#region Configuration
    [Header("Configuration")]
    [SerializeField]
    protected FloatReference Acceleration;
    [SerializeField]
    protected FloatReference MoveSpeed;
#endregion

#region Variables
    [Header("Variables")]
    [SerializeField]
    protected BoolReference UnableToMove;
    [SerializeField]
    protected Vector2Reference Direction;
    [SerializeField]
    protected Vector2Reference Velocity;
    [SerializeField]
    protected Vector2Reference DesirableVelocity;
#endregion

    protected Rigidbody2D rigidbody;

    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        
        DesirableVelocity.Value = Direction.Normalized * MoveSpeed.Value;

        if(!UnableToMove.Value) {
            Vector2 velocity = Velocity.Value;
            velocity = Vector2.MoveTowards(velocity, DesirableVelocity.Value, Acceleration.Value * Time.deltaTime);
            Velocity.Value = velocity;
        }

    }

    protected virtual void FixedUpdate()
    {
        rigidbody.velocity = Velocity.Value;
        // rigidbody.MovePosition(transform.position + (Vector3)(Velocity.Value * Time.fixedDeltaTime));
    }


}
