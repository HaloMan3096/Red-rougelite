using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // play chest opening animation

    // Interacting logic
    public Interact OpenFromInteraction;

    private void Awake()
    {
        OpenFromInteraction = this.GetComponent<Interact>();
    }

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

    public void OpenChest()
    {
        Debug.Log("Opening Chest");
    }
}
