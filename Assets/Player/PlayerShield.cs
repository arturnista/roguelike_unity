using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{

#region Configuration
    [Header("Configuration")]
    [SerializeField]
    protected PlayerInventory Inventory;
    [SerializeField]
    protected Vector2Reference LookDirection;
#endregion

#region Variables
    [Header("Variables")]
    [SerializeField]
    protected FloatReference MoveSpeed;
    [SerializeField]
    protected Vector2Reference Velocity;
    [SerializeField]
    protected DamageEvent ShieldBlockEvent;
#endregion

    private bool isShieldActive;
    private Transform shield;

    void Awake()
    {
        shield = transform.Find("PlayerShield");
        DeactivateShield();
    }

    void OnEnable()
    {
        ShieldBlockEvent.Actions += ShieldBlock;
    }

    void OnDisable()
    {
        ShieldBlockEvent.Actions -= ShieldBlock;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1)) ActivateShield();
        else if(Input.GetKeyUp(KeyCode.Mouse1)) DeactivateShield();

        if(isShieldActive)
        { 
            float angle = Mathf.Atan2(LookDirection.Value.y, LookDirection.Value.x) * Mathf.Rad2Deg;
            shield.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
            shield.localPosition = LookDirection.Value;
        }
    }

    void ActivateShield()
    {
        if(Inventory.CurrentShield == null) return;

        isShieldActive = true;
        shield.gameObject.SetActive(true);
        MoveSpeed.Value *= Inventory.CurrentShield.MoveSpeedMultiplier;
    }

    void DeactivateShield()
    {
        isShieldActive = false;
        shield.gameObject.SetActive(false);
        MoveSpeed.ResetValue();
    }

    void ShieldBlock()
    {
        Velocity.Value += (-ShieldBlockEvent.Hit.normal * ShieldBlockEvent.Damage) * Inventory.CurrentShield.DamageMultiplier;
    }

}
