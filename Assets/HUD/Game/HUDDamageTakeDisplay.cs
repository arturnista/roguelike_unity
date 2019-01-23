using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDamageTakeDisplay : MonoBehaviour
{
    
    public FloatReference Health;
    public Color damageColor;

    private Image damageDisplayImage;
    private float lastHealth;

    void Awake()
    {
        damageDisplayImage = GetComponent<Image>();
        damageDisplayImage.enabled = false;
        
        lastHealth = Health.Value;
    }

    void Update()
    {
        if(lastHealth != Health.Value)
        {
            lastHealth = Health.Value;
            StartCoroutine(EffectDisplay());
        }
    }

    IEnumerator EffectDisplay() {
        damageDisplayImage.color = damageColor;
        damageDisplayImage.enabled = true;

        while(damageDisplayImage.color.a > 0) {
            Color color = damageDisplayImage.color;
            color.a -= Time.deltaTime;
            damageDisplayImage.color = color;
            
            yield return null;
        }

        damageDisplayImage.enabled = false;
    }

}
