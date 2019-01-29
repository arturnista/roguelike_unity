using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHealthBarDisplay : MonoBehaviour
{
    
    public FloatReference MaxHealth;
    public FloatReference Health;
    public AnimationCurve DisplayCurve;

    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
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
        float size = DisplayCurve.Evaluate(Health.Value / MaxHealth.Value);
        image.rectTransform.localScale = new Vector3(size, 1f, 1f);
    }

}
