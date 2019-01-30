using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpritePerHealth : MonoBehaviour
{
    
    [System.Serializable]
    public struct SpritePerHealth
    {   
        public float Limit;
        public Sprite Sprite;
    }

    public FloatReference Health;
    public List<SpritePerHealth> Sprites;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void OnEnable()
    {
        Health.OnChangeValue += OnChangeHealth;
    }

    void OnDisable()
    {
        Health.OnChangeValue -= OnChangeHealth;
    }

    void OnChangeHealth(float lastHealth)
    {
        SpritePerHealth spritePerHealth = Sprites.FindLast(x => x.Limit >= Health.Value);
        if(spritePerHealth.Sprite == null) return;
        spriteRenderer.sprite = spritePerHealth.Sprite;
    }

}
