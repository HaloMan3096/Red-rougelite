using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // change the chest to the open state sprite

    // Interacting logic
    public Interact OpenFromInteraction;

    private void Awake()
    {
        OpenFromInteraction = this.GetComponent<Interact>();
    }

    // when the object is created we subscribe the OBJ to the hasInteracted event
    private void OnEnable()
    {
        if (OpenFromInteraction)
        {
            OpenFromInteraction.GetInteractEvent.HasInteracted += OpenChest;
        }
    }
    // subscribing an event uses memory so we must unsubscribe when the OBJ is destroyed/disabled
    private void OnDisable()
    {
        if (OpenFromInteraction)
        {
            OpenFromInteraction.GetInteractEvent.HasInteracted -= OpenChest;
        }
    }

    // Logic for what happens when you open the chest
    public void OpenChest()
    {
        Debug.Log("Opening Chest");
    }
}
