using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public Color currentColor;
    public bool fixColor = false;

    private void Start()
    {
        currentColor = Color.gray;
    }

    private void Update()
    {
        transform.GetComponent<Renderer>().material.color = currentColor;
        if (fixColor) FixColor();
    }

    public void FixColor()
    {
        currentColor = Color.gray;
    }
}
