using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatCtrl : MonoBehaviour
{
    [SerializeField] private PlayerCtrl player;
    [SerializeField] private DeathCtrl death;

    [SerializeField] private GameObject health;
    [SerializeField] private GameObject stamina;
    [SerializeField] private GameObject mana;

    public void ChangeHealth(float amount)
    {
        health.transform.right += new Vector3(0, 0, amount);
        if(player.health <= 90)
        {
            player.health += amount;
            player.health = Mathf.Ceil(player.health);
            player.health = Mathf.Clamp(player.health, 0, 90);
        }
        if(player.health <= 0)
        {
            death.FadeToBlack();
        }
    }

    public void ChangeStamina(float amount)
    {
        stamina.transform.right += new Vector3(amount, 0);
    }

    public void ChangeMana(float amount)
    {
        mana.transform.right += new Vector3(amount, 0);
    }
}
