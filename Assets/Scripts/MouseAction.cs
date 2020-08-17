using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouseAction : MonoBehaviour
{
    public GameObject messageBox;
    public TextMeshProUGUI messageText;

    public Vector3 offset;
    private Vector3 originalScale;

    Ray ray;
    RaycastHit2D hit;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Selectable"))
            {
                messageBox.SetActive(true);
                originalScale = hit.collider.transform.localScale;
                transform.localScale = originalScale + offset;

                if (!hit.collider.name.Equals("Shaker"))
                {
                    messageText.text = hit.collider.name;
                }
            } else if (hit.collider.CompareTag("Table"))
            {
                Drink drink = hit.collider.GetComponent<Table>().drink;
                if(drink != null)
                {
                    messageBox.SetActive(true);
                    originalScale = hit.collider.transform.localScale;
                    transform.localScale = originalScale + offset;
                    messageText.text = drink.name;
                }
            }
        } else
        {
            transform.localScale = originalScale;
            messageBox.SetActive(false);
            messageText.text = "";
        }
    }
}
