using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

/// <summary>
/// Used to remove an unspecified amount of tiles allowing the player to move
/// The designer should add a copy of the open door underneth if there is one
/// </summary>
public class Lever : MonoBehaviour
{
    // Get tile/tilemap reference
    [SerializeField] Tilemap doorTileMap;
    [SerializeField] Vector3Int[] tilePositions;

    // Interacting logic
    public Interact OpenFromInteraction;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        OpenFromInteraction = this.GetComponent<Interact>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
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
        ShowChange();
        // we dont know how many tiles a given lever will disable so we use a foreach loop
        foreach (Vector3Int i in tilePositions)
        {
            doorTileMap.SetTile(i, null);
        }
    }

    // Just for the test enviroment we want to show that the lever has been interacted with
    private void ShowChange()
    {
        spriteRenderer.color = Color.black;
    }
}
