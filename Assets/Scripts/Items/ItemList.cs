using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemList
{
    public Item item;
    public string name;
    public int stacks;

    // On the ItemList creation we need to set the values
    public ItemList(Item newItem, string newName, int newStacks)
    {
        item = newItem;
        name = newName;
        stacks = newStacks;
    }
}
