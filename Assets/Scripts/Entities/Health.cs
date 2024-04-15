using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    
    // Semi-Constant because we might want to change health values
    private int MAX_HEALTH = 100;
    public int GetMaxHealth() { return MAX_HEALTH; }
    
    void Update()
    {

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
