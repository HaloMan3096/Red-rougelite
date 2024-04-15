using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    InteractEvent interact = new InteractEvent();
    Player player;

    // create an interact if there is none 
    public InteractEvent GetInteractEvent
    {
        get
        {
            if (interact == null) interact = new InteractEvent();
            return interact;
        }
    }

    public Player GetPlayer
    {
        get
        {
            return player;
        }
    }

    /// <summary>
    /// calls the interact event on the InteractEvent
    /// </summary>
    /// <param name="interactedPlayer"></param>
    public void CallInteract(Player interactedPlayer)
    {
        player = interactedPlayer;
        interact.CallInteractEvent();
    }
}

// Using the delegate allows for any number of events to happen when you interact
public class InteractEvent
{
    public delegate void InteractHandler();

    public event InteractHandler HasInteracted;

    public void CallInteractEvent() => HasInteracted?.Invoke();
}