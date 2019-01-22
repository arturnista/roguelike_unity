using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    
#region Configuration
    [Header("Configuration")]
    [SerializeField]
    private FloatReference Speed;
    [SerializeField]
    private FloatReference Cooldown;
#endregion

#region Variables
    [Header("Variables")]
    [SerializeField]
    private Vector2Reference Direction;
    [SerializeField]
    private Vector2Reference Velocity;
#endregion

#region Effects
    [Header("Effects")]
    [SerializeField]
    private GameObject DashEffect;
#endregion

    private Rigidbody2D rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        Cooldown.Value -= Time.deltaTime;      
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        } 
    }

    public void Dash()
    {
        if(Cooldown.Value > 0f) return;
        if(Direction.Value == Vector2.zero) return;

        Cooldown.Variable.ResetValue();
        if(DashEffect)
        {
            Instantiate(DashEffect, transform.position, Quaternion.identity);
        }
        Velocity.Value += Direction.Value.normalized * Speed.Value;
    }

}
