using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDChangeLifeDisplay : MonoBehaviour
{
    
    public FloatReference Health;
    public float EffectRate;
    public Color DamageColor;
    public Color GainColor;

    private Image damageDisplayImage;
    private float lastHealth;

    void Awake()
    {
        damageDisplayImage = GetComponent<Image>();
        damageDisplayImage.enabled = false;
    }

    void OnEnable()
    {
        Health.OnChangeValue += this.OnChangeHealth;
    }

    void OnDisable()
    {
        Health.OnChangeValue -= this.OnChangeHealth;
    }

    void OnChangeHealth(float lastValue)
    {
        StartCoroutine(EffectDisplay(lastValue > Health.Value));
    }

    IEnumerator EffectDisplay(bool damaged) {
        damageDisplayImage.color = damaged ? DamageColor : GainColor;
        damageDisplayImage.enabled = true;

        while(damageDisplayImage.color.a > 0) {
            Color color = damageDisplayImage.color;
            color.a -= Time.deltaTime * EffectRate;
            damageDisplayImage.color = color;
            
            yield return null;
        }

        damageDisplayImage.enabled = false;
    }

}
