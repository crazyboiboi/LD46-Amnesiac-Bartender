using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    public Drink[] drinks;
    public Drink defaultDrink;

    public Drink GetDrinkByCombo(string c)
    {
        foreach(Drink d in drinks)
        {
            if(d.combination.Equals(c))
            {
                return d;
            }
        }
        //Return a default drink HERE
        defaultDrink.combination = c;
        return defaultDrink;
    }

    public Drink GetDrinkByName(string n)
    {
        foreach (Drink d in drinks)
        {
            if (d.name.Equals(n))
            {
                return d;
            }
        }
        return null;
    }

    public Drink generateRandomDrink()
    {
        return drinks[Random.Range(0, drinks.Length)];
    }

    void OnMouseDown()
    {
        GUIManager.instance.OpenRecipe();
    }

}
