using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public int closingHour;

    public float rating;
    public float ratingMultiplier;

    public float daySpeed;
    int day = 1;
    int maxDay = 7;

    float timer = 0;
    int currentHour = 22;
    int currentMinute = 0;

    public bool barClosed = false;
    bool isGameOver = true;
    bool runCredit = false;

    void Awake()
    {
        Screen.fullScreen = false;
    }

    void Update()
    {
        if(!isGameOver)
        {
            Time.timeScale = 1;
            if (!barClosed)
            {
                if(currentHour != closingHour)
                {
                    if (rating < 0)
                    {
                        rating = 0;
                    } else
                    {
                        rating -= Time.deltaTime * ratingMultiplier;
                        GUIManager.instance.SetRatingSlider(rating);
                    }

                    //One cycle adds one hour to the clock
                    if (timer < 60.0f)
                    {
                        timer += Time.deltaTime * daySpeed;
                        currentMinute = (int)timer;
                        currentMinute %= 60;
                        GUIManager.instance.SetCurrentTime(currentHour, currentMinute);
                    }
                    else
                    {
                        currentHour++;
                        currentHour %= 24;
                        GUIManager.instance.SetCurrentTime(currentHour, currentMinute);
                        timer = 0.0f;
                    }
                }
                //Close business and adds one to day then proceed to shop
                else
                {
                    day++;
                    GUIManager.instance.SetDay(day);
                    barClosed = true;
                    Debug.Log("Starting day " + day);
                    currentHour = 22;

                    //Check for game over
                    if (day > maxDay)
                    {
                        isGameOver = true;
                        runCredit = true;
                        Debug.Log("Game OVER");
                    }
                }
            }
            else
            {
                //When day ends, allow the player to continue upon mouse click
                GUIManager.instance.overlay.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    GUIManager.instance.overlay.SetActive(false);
                    barClosed = false;
                }
            }
        } else
        {
            if (runCredit)
            {
                GUIManager.instance.endScreen.SetActive(true);
                GUIManager.instance.overlay.SetActive(false);

                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            else
            {
                //Check if the main menu screen is active, if it is then game over
                Time.timeScale = 0.0f;
                isGameOver = GUIManager.instance.mainMenuScreen.activeInHierarchy;
            }
        }
    }
}
