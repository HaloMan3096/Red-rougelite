using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int Health;
    public int Stamina { get { return Stamina; } set {  Stamina = maxStamina; }}
    public int Mana    { get { return Mana; }    set {  Mana = maxMana; }}

    private int maxHealth  = 100;
    private int maxStamina = 150;
    private int maxMana    = 50;

    [SerializeField] public List<ItemList> items = new List<ItemList>();

    private void Start()
    {
        StartCoroutine(CallItemUpdate());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PlayerInteract();
    }

    public void testing()
    {
        Debug.Log("Got Player Script");
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

    // get private values
    public int GetMaxHealth() { return maxHealth; }
    public int GetMaxMana() {  return maxMana; }
    public int GetMaxStamina() { return maxStamina; }

    // Interacting

    public void PlayerInteract()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(this.gameObject.transform.position, new Vector2(0,1), 1f);
        Debug.DrawRay(this.gameObject.transform.position, new Vector3(0,1,0), Color.red);

        if (raycastHit2D.transform == null)
        {
            Debug.Log("Dosent exist");
        }

        Interact interact = null;
        if (raycastHit2D.transform.TryGetComponent<Interact>(out Interact _interact))
        {
            Debug.Log("Hit Sumthin");
            interact = _interact;
        }

        interact = raycastHit2D.transform.GetComponent<Interact>();
        if (interact)
        {
            Debug.Log("Interactin Here");
            interact.CallInteract(this);
        }
    }
}
