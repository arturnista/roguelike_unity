using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : Attackable
{

    [System.Serializable]
    public struct SwitchAction
    {
        public string name;        
        public Sprite Sprite;        
        public UnityEvent Events;
    }

    public int InitialAction = 0;
    public List<SwitchAction> Actions;

    private SpriteRenderer spriteRenderer;
    private int currentActionIndex;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        DispatchAction(InitialAction);        
    }

    void DispatchNextAction()
    {
        DispatchAction((currentActionIndex + 1) % Actions.Count);
    }

    void DispatchAction(int index)
    {
        currentActionIndex = index;
        SwitchAction action = Actions[currentActionIndex];
        action.Events.Invoke();
        spriteRenderer.sprite = action.Sprite;
    }
    
    public override void DealDamage(float damage, RaycastHit2D hit, Transform damager)
    {
        base.DealDamage(damage, hit, damager);
        DispatchNextAction();
    }

}
