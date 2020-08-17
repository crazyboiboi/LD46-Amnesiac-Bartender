using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour
{
    public int ingredientNumber;

    public Color hoverColour;

    private Color startColour;
    private Renderer rend;

    private Shaker shaker;

    public Vector3 offset;
    private Vector3 originalScale;

    public string soundEffectName;

    void Start()
    {
        rend = GetComponent<Renderer>();

        originalScale = transform.localScale;

        shaker = GameObject.Find("Shaker").GetComponent<Shaker>();

        startColour = rend.material.color;
    }


    void OnMouseDown()
    {
        //Add to shaker 
        shaker.AddIngredient(ingredientNumber, soundEffectName);
        Debug.Log("Adding " + name + "...");
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
