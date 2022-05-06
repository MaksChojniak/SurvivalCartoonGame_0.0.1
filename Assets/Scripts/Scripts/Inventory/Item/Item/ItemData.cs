using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Unity Item Data", order = 0)]
public class ItemData : ScriptableObject
{
    public string Name;
    public int ID;

    public bool stackable;
    public int maxStack;

    public string typeOfItem;


}

