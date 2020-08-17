using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Table : MonoBehaviour
{
    public TextMeshProUGUI messageText;

    public Color hoverColour;
    private Color startColour;

    public Bar bar;
    public Recipe recipe;
    public Chair chair;

    public SpriteRenderer drinkArt;

    public Drink drink;

    void Start()
    {
        drink = null;
        startColour = drinkArt.material.color;
    }

    public void setDrink(Drink drink)
    {
        this.drink = drink;
    }

    public bool hasDrink()
    {
        return drink != null;
    }

    public void ServeDrink()
    {
        Customer customer = chair.customer;
        string customerDrinkName = customer.preferredDrink;
        string grade = "Perfect";

        //Check customer drink and made drink
        if (!customerDrinkName.Equals(drink.name))
        {
            Drink customerDrink = recipe.GetDrinkByName(customerDrinkName);
            grade = GradeDrink(customerDrink, drink);
        }
        Debug.Log(grade);

        AudioManager.instance.Play("Slurp");

        //Modify rating here and display customer's end message
        bar.rating += CalculateRating(customer.patienceLevel, grade);
        customer.endMessage = Dialog.endMessage[grade];
        chair.dialog.text = customer.endMessage;
        chair.customer.isServed = true;
        chair.customer = null;
    }


    //Needs to find another system to calculate rating
    float CalculateRating(float patienceLevel, string grade)
    {
        float rating;
        switch(grade)
        {
            case "Perfect":
                rating = 1f;
                break;
            case "Good":
                rating = 0.5f;
                break;
            case "Decent":
                rating = -0.1f;
                break;                
            default:
                rating = -0.25f;
                break;
        }
        return rating * patienceLevel * 0.25f;
    }


    string GradeDrink(Drink d1, Drink d2)
    {
        List<char> n1 = d1.combination.ToList();   
        List<char> n2 = d2.combination.ToList();    
        var diff = n1.Except(n2).ToList();         
        
        if(diff.Count == 0)
        {
            return "Good";
        } else if(diff.Count < 2)
        {
            return "Decent";
        }
        return "Bad";
    }


    void OnMouseDown()
    {
        if (chair.customer != null && chair.customer.isServed == false)
        {
            //Check if we have a drink to serve
            if (drink != null)
            {
                //Serve the drink
                ServeDrink();
                drink = null;
                drinkArt.sprite = null;
                drinkArt.material.color = startColour;
                Debug.Log("Drink removed!");
            }
            else
            {
                Debug.Log("Empty");
            }
        } else
        {
            Debug.Log("Action cannot be done");
        }
    }

    void OnMouseEnter()
    {
        if(drink != null)
        {
            drinkArt.material.color = hoverColour;
        }
    }

    void OnMouseExit()
    {
        if(drink != null)
        {
            drinkArt.material.color = startColour;
        }
    }


}
