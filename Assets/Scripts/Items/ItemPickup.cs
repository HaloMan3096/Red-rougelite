using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public Items itemDrop;

    private void Start()
    {
        item = AssignItem(itemDrop);
    }

    // When the player enters the 2d collider add it to the player 'inventory' and destroy this
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            AddItem(player);
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Adding the item that is selected 
    /// </summary>
    /// <param name="player"></param>
    public void AddItem(Player player)
    {
        foreach (ItemList i in player.items)
        {
            if (i.name == item.GiveName())
            {
                i.stacks += 1;
                return;
            }
        }
        player.items.Add(new ItemList(item, item.GiveName(), 1));
    }

    /// <summary>
    /// create a item based on what item is chosen from the enum
    /// </summary>
    /// <param name="itemToAssign"></param>
    /// <returns></returns>
    public Item AssignItem(Items itemToAssign)
    {
        switch (itemToAssign)
        {
            case Items.HealingItem: return new HealingItem();
            case Items.KeyItem: return new KeyItem();
            case Items.FireDMGItem: return new FireDMGItem();
            default: return null;
        }
    }
}

// The list of items
public enum Items
{
    HealingItem,
    KeyItem,
    FireDMGItem
}