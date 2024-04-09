using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public abstract class Item
{
    public abstract string GiveName();

    public virtual void update(Player player, int stacks) { }

    public virtual void update(Player player, int stacks, ItemList item) { }

    public virtual void OnHit(Player player, int stacks) { }
}

// Healing items...
public class HealingItem : Item
{
    public override string GiveName()
    {
        return "Healing Item";
    }

    public override void update(Player player, int stacks, ItemList item)
    {
        if (player.Health >= player.GetMaxHealth())
            return;

        player.Health += 3 + (2 * stacks);
    }
}

public class KeyItem : Item
{
    public override string GiveName()
    {
        return "key";
    }
}

public class FireDMGItem : Item
{
    public override string GiveName()
    {
        return "Fire Damage Item";
    }
}