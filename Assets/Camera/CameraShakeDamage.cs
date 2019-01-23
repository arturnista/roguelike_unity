using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraShakeDamage : MonoBehaviour
{
    
    public FloatReference Health;

    private float lastHealth;

    void Start()
    {
        lastHealth = Health.Value;        
    }

    void Update()
    {
        
        if(lastHealth != Health.Value)
        {
            if(Health.Value < lastHealth) ShakeCamera(lastHealth - Health.Value);
            lastHealth = Health.Value;
        }

    }

    void ShakeCamera(float amount) {
        CameraShaker.Instance.ShakeOnce(2f, amount / 5f, 0.1f, .5f);
    }
}
