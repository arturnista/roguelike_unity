using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUse : MonoBehaviour
{

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }

    }

    void Use()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (Collider2D collider in colliders)
        {
            IUsable usable = collider.GetComponent<IUsable>();
            if (usable != null) usable.Use(transform);
        }
    }

}