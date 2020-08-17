using System.Collections;
using System.Collections.Generic;

public class Dialog
{
    public static string[] drinks =
    {
        "Apple Martini",
        "Bloody Mary",
        "Dark n Stormy",
        "Gimlet",
        "Long Island Ice Tea",
        "Margarita",
        "Martini",
        "Mimosa",
        "Mint Julep",
        "Paloma",
        "The Dalmatian",
        "Whiskey Sour",
        "Default"
    };

    public static Dictionary<string, string> endMessage = new Dictionary<string, string>
    {
        { "Perfect", "Perfect! That was what I was looking for" },
        {"Good", "Nah, seems closed but I would not give you a 100" },
        {"Decent", "Well, I think you may need some more practice." },
        {"Bad", "Nope, I don't think I will visit this place again" }
    };


}
