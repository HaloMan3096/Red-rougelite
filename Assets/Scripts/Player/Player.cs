using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<ItemList> items = new List<ItemList>();
    public Health health;
    public int numOfGems;
    [SerializeField] FadeToBlack fade;

    // Get the health script and start the item CoRoutine
    private void Start()
    {
        health = GetComponent<Health>();
        StartCoroutine(CallItemUpdate());
    }

    // Checks for inputs
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PlayerInteract();
    }

    private void OnDestroy()
    {
        if(health.GetHealthAmount() <= 0)
        {
            FadeToBlack.StartFade("DeathScene", fade);
        }
    }

    // activate the update function on the items
    private IEnumerator CallItemUpdate()
    {
        foreach (ItemList i in items)
        {
            i.item.update(this, i.stacks, i);
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(CallItemUpdate());
    }

    /// <summary>
    /// Returns a V2 in the direction that the player is facing
    /// </summary>
    /// <returns></returns>
    public Vector2 GetDirection()
    {
        Vector2 result = Vector2.zero;

        // Get the last dirrection
        Animator animator = this.GetComponent<Animator>();
        float lastHorizontal = animator.GetFloat("LastHorizontal");
        float lastVertical = animator.GetFloat("LastVertical");

        // we compair the values using absolute value and then check if its negitive
        if (Mathf.Abs(lastHorizontal) > Mathf.Abs(lastVertical))
        {
            if(lastHorizontal < 0)
            {
                return new Vector2(-1, 0);
            }
            else
            {
                return new Vector2(1, 0);
            }
        }
        if (Mathf.Abs(lastHorizontal) < Mathf.Abs(lastVertical))
        {
            if(lastVertical < 0)
            {
                return new Vector2(0, -1);
            }
            else
            {
                return new Vector2(0, 1);
            }
        }

        return result;
    }

    // Interacting
    public void PlayerInteract()
    {
        // get the direction the player is facing and do a raycast in that direction
        RaycastHit2D raycastHit2D = Physics2D.Raycast(this.gameObject.transform.position, GetDirection(), 1f);

        // null check to avoid null ref. error
        if (raycastHit2D.transform == null) { return; }

        Interact interact = raycastHit2D.transform.GetComponent<Interact>();
        if (interact) { interact.CallInteract(this); }
    }
}
