using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public TextMeshProUGUI messageText;

    public Table table;
    public SpriteRenderer drinkArt;

    public Color hoverColour;
    private Color startColour;
    private Renderer rend;

    public Recipe recipe;

    private List<int> ingredients;
    private int availableSlots;

    public Vector3 offset;
    private Vector3 originalScale;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;

        originalScale = transform.localScale;

        ingredients = new List<int>();
        availableSlots = 8;
    }

    /* Adds the ingredient into the shaker
     * This is called from Ingredient
     */
    public void AddIngredient(int ingredient, string soundEffect)
    {
        if (availableSlots >= 0)
        {
            AudioManager.instance.Play(soundEffect);
            ingredients.Add(ingredient);
            availableSlots--;
        }
        else
        {
            Debug.Log("Shaker is full");
        }
    }


    /* Requires shaking sound effect
     * Obtain the final drink result
     * Reset the shaker to default state
     */
    public void Shake()
    {
        //Check if the table already has a drink waiting to be served
        if(!table.hasDrink() && ingredients.Count != 0)
        {
            AudioManager.instance.Play("Shaker Shaking");

            string result = "";

            //Convert the ingredients into a string for comparing
            ingredients.Sort();
            foreach (int i in ingredients)
            {
                result += i;
            }

            //Get drink based on combo
            Drink drink = recipe.GetDrinkByCombo(result);
            table.setDrink(drink);
            Debug.Log("You made " + drink.name + ". The combo was: " + drink.combination);
            drinkArt.sprite = drink.artwork;
            ResetShaker();
        } else
        {
            Debug.LogError("Throw away your current drink first!");
        }        
    }

    void ResetShaker()
    {
        ingredients.Clear();
        availableSlots = 8;
    }

    void OnMouseDown()
    {
        Shake();
    }

    void OnMouseEnter()
    {
        if(ingredients.Count == 0)
        {
            messageText.text = "Shaker [Empty]";
        } else
        {
            ingredients.Sort();
            messageText.text = "Shaker [" + string.Join("", ingredients.ToArray()) + "]";
        }
        transform.localScale = originalScale + offset;
        rend.material.color = hoverColour;
    }

    void OnMouseExit()
    {
        transform.localScale = originalScale;
        rend.material.color = startColour;
    }

}
