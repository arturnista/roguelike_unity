using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHealthBarDisplay : MonoBehaviour
{
    
    public FloatReference MaxHealth;
    public FloatReference Health;

    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        float size = Health.Value / MaxHealth.Value;
        image.rectTransform.localScale = new Vector3(size, 1f, 1f);
    }

}
