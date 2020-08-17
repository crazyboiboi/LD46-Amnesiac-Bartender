using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public Recipe recipe;

    public GameObject mainMenuScreen;
    public GameObject recipeMenuScreen;
    public GameObject overlay;

    public Slider ratingSlider;

    public TextMeshProUGUI dayText;
    public TextMeshProUGUI timeText;

    public TextMeshProUGUI drinkNameText;
    public TextMeshProUGUI drinkComboText;
    public TextMeshProUGUI drinkDescriptionText;

    public GameObject endScreen;

    public void StartGame()
    {
        mainMenuScreen.SetActive(false);
    }

    public void OpenRecipe()
    {
        recipeMenuScreen.SetActive(!recipeMenuScreen.activeInHierarchy);
        drinkNameText.text = "";
        drinkComboText.text = "";
        drinkDescriptionText.text = "";
    }

    public void SetRatingSlider(float rating)
    {
        ratingSlider.value = rating;
    }

    public void SetCurrentTime(int currentHour, int currentMinute)
    {
        timeText.text = string.Format("{0:D2}:{1:D2}", currentHour, currentMinute);
    }

    public void SetDay(int day)
    {
        dayText.text = "Day" + day;
    }

    public void ViewDrinkRecipe(string drinkName)
    {
        Drink drink = recipe.GetDrinkByName(drinkName);
        drinkNameText.text = drink.name;
        drinkComboText.text = "[" + drink.combination + "]";
        drinkDescriptionText.text = drink.description;
    }

}
