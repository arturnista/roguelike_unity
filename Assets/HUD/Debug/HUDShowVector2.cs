using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDShowVector2 : MonoBehaviour
{

    [SerializeField]
    private Vector2Reference Reference;
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Reference.Variable.ToString();
    }
}
