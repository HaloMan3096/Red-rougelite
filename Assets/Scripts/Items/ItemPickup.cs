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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            AddItem(player);
            Destroy(this.gameObject);
        }
    }

    public void AddItem(Player player)
    {
        Debug.Log("We addin here");
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

public enum Items
{
    HealingItem,
    KeyItem,
    FireDMGItem
}