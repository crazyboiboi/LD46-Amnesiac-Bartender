using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public Table table;

    public Color hoverColour;
    private Color startColour;
    private Renderer rend;

    public Vector3 offset;
    private Vector3 originalScale;

    void Start()
    {
        rend = GetComponent<Renderer>();

        originalScale = transform.localScale;

        startColour = rend.material.color;
    }


    void OnMouseDown()
    {
        if(table.drink != null)
        {
            table.drink = null;
            table.drinkArt.sprite = null;
            Debug.Log("Drink removed!");
        }
        
    }

    void OnMouseEnter()
    {
        transform.localScale = originalScale + offset;
        rend.material.color = hoverColour;
    }

    void OnMouseExit()
    {
        transform.localScale = originalScale;
        rend.material.color = startColour;
    }
}
