using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Lever : MonoBehaviour
{
    // Get tile/tilemap reference
    [SerializeField] Tilemap doorTileMap;
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
            OpenFromInteraction.GetInteractEvent.HasInteracted += removeTile;
        }
    }
    // subscribing an event uses memory so we must unsubscribe when the OBJ is destroyed/disabled
    private void OnDisable()
    {
        if (OpenFromInteraction)
        {
            OpenFromInteraction.GetInteractEvent.HasInteracted -= removeTile;
        }
    }

    // remove the specific tile
    public void removeTile()
    {
        Debug.Log("Lever Flipped");
    }
}
