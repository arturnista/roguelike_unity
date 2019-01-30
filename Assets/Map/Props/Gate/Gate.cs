using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    public enum Status {
        Open,
        Close
    }

    public Status InitialStatus = Status.Close;
    
    protected Status currentStatus;
    
    protected Sprite sprite;
    protected SpriteRenderer spriteRenderer;
    protected Collider2D collider2D;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        sprite = spriteRenderer.sprite;

        if(InitialStatus == Status.Close) Close();
        else Open();
    }

    public void Toggle()
    {
        if(currentStatus == Status.Close) Open();
        else Close();
    }

    public virtual void Close()
    {
        currentStatus = Status.Close;
        spriteRenderer.enabled = true;
        collider2D.enabled = true;
    }

    public virtual void Open()
    {
        currentStatus = Status.Open;
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
    }

}
