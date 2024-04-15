using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

/// <summary>
/// Used to remove an unspecified amount of tiles allowing the player to move
/// </summary>
public class Lever : MonoBehaviour
{
    // Get tile/tilemap reference
    [SerializeField] Tilemap doorTileMap;
    [SerializeField] Vector3Int[] tilePositions;

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

    // remove the specific tile(s)
    public void removeTile()
    {
        // we dont know how many tiles a given lever will disable so we use a foreach loop
        foreach(Vector3Int i in tilePositions)
        {
            doorTileMap.SetTile(i, null);
        }
    }
}
