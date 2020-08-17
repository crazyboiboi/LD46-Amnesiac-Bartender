using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Drink", menuName = "Drink")]
public class Drink : ScriptableObject
{
    public new string name;
    public string combination;
    public string customerRequest;
    public string description;


    public Sprite artwork;


}
