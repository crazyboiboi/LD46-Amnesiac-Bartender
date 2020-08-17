using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public GameObject chair;

    public string preferredDrink;
    public string drinkDescription;
    public string endMessage;

    public bool isServed;
    public bool inPosition;

    public float patienceLevel = 2;

    private void Update()
    {
        if (inPosition)
        {
            patienceLevel -= (float)0.05 * Time.deltaTime;

            if (patienceLevel < 0 || isServed)
            {
                transform.Translate(-2.0f * Time.deltaTime, 0, 0);
                Destroy(this.gameObject, 2.5f);
            }
        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, chair.transform.position, 2.0f * Time.deltaTime);
        }


    }

}