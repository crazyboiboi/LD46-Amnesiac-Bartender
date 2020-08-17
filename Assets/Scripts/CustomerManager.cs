using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than 1 customer manager in scene!");
            return;
        }
        instance = this;    
    }

    public GameObject customerPrefab;

    public Sprite[] customerSprites;

    public Recipe recipe;

    void Start()
    {
        newCustomer = customerPrefab;
    }

    private GameObject newCustomer;

    public GameObject GetNewCustomer()
    {
        int type = Random.Range(0, 3);
        Customer script = newCustomer.GetComponent<Customer>();
        newCustomer.GetComponent<SpriteRenderer>().sprite = customerSprites[type];

        Drink drink = recipe.generateRandomDrink();
        script.preferredDrink = drink.name;
        script.drinkDescription = drink.customerRequest;

        return newCustomer;
    }




}
