using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    public List<GameObject> queue;

    public Bar bar;

    public Chair chair;

    float timer;

    void Update()
    {
        //If bar is closed, we need to clear the queue and mark chair as unoccupied
        if(bar.barClosed)
        {
            queue.Clear();
            chair.occupied = false;
        } 
        //We can generate new customer as well as sending customer for service
        else
        {
            //Timer implementation of generating new customer (every 1 second)
            if (queue.Count < 5)
            {
                if(timer < 1.0f)
                {
                    timer += Time.deltaTime;
                } else
                {
                    //Generate customers based on chance
                    int num = Random.Range(0,21);
                    if(num > 12)
                    {
                        GameObject customerToQueue = CustomerManager.instance.GetNewCustomer();
                        queue.Add(customerToQueue);
                    }
                    timer = 0.0f;
                }
            }

            //We can send in a customer if the chair isn't occupied and we have a customer waiting in line
            if (!chair.occupied && queue.Count != 0)
            {
                Instantiate(queue[0], transform.position, transform.rotation);
                chair.occupied = true;
                queue.RemoveAt(0);
            }
        }        
    }

}

