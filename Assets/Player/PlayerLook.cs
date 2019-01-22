using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

#region Variables
    [Header("Variables")]
    [SerializeField]
    protected Vector2Reference LookDirection;
#endregion

    private Camera camera;

    void Awake()
    {
        camera = Camera.main;        
    }

    void Update()
    {
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        LookDirection.Value = (mousePosition - transform.position).normalized;
    }
}
