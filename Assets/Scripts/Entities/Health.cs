using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    // Just for testing
    [SerializeField] private TextMeshProUGUI textBox;
    private float textTimer = 1.5f;
    private float timer = 0;
    public bool gotHit;
    
    // Semi-Constant because we might want to change health values
    private int MAX_HEALTH = 100;
    public int GetMaxHealth() { return MAX_HEALTH; }
    
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }

        if (gotHit)
        {
            timer += Time.deltaTime;
        }

        if (timer !>= textTimer && textBox != null)
        {
            Debug.Log("Turning off the text box");
            timer = 0;
            gotHit = false;
            textBox.gameObject.SetActive(false);
        }
    }

    public int GetHealthAmount()
    {
        return health;
    }

    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }

    /// <summary>
    /// Takes in a int named amount and removes it from the health total as long as it is positive
    /// </summary>
    /// <param name="amount"></param>
    /// <exception cref="System.ArgumentOutOfRangeException"></exception>
    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot Have Negitive Damage");
        }

        if (health - amount <= 0)
        {
            Die();
        }

        Debug.Log($"Entity: {this} Got hit for {amount} DMG");

        if(textBox != null)
        {
            Debug.Log("Turning on the text box");
            textBox.gameObject.SetActive(true);
            timer = 0;
            textBox.color = Color.red;
            textBox.text = $"-{amount}";
            gotHit = true;
        }

        this.health -= amount;
    }

    /// <summary>
    /// Takes in an int "amount" and adds it to health as long as its positive and cap it at the MAX_HEALTH value
    /// </summary>
    /// <param name="amount"></param>
    /// <exception cref="System.ArgumentOutOfRangeException"></exception>
    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot Have Negitive Healing");
        }

        if (health + amount > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    /// <summary>
    /// Destroy's the game object for now
    /// </summary>
    private void Die()
    {
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    }
}
