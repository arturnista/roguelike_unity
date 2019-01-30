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
    
    private Status currentStatus;
    
    private Sprite sprite;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;

    void Awake()
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

    public void Close()
    {
        currentStatus = Status.Close;
        spriteRenderer.enabled = true;
        collider2D.enabled = true;
    }

    public void Open()
    {
        currentStatus = Status.Open;
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
    }

}
