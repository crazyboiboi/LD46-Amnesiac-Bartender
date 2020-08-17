using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public GameObject chatBubble;
    public TextMeshProUGUI dialog;

    public bool occupied = false;

    public Table table;
    public Bar bar;

    public Customer customer;

    void Update()
    {
        //Check if the bar is closed
        if(bar.barClosed)
        {
            customer.isServed = true;
            customer = null;
            chatBubble.SetActive(false);
            occupied = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Customer"))
        {
            customer = other.gameObject.GetComponent<Customer>();
            customer.inPosition = true;
            dialog.text = customer.drinkDescription;
            chatBubble.SetActive(true);
            occupied = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        customer = null;
        chatBubble.SetActive(false);
        occupied = false;
    }


}
