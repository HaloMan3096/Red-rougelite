using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatCtrl : MonoBehaviour
{
    private PlayerCtrl player;
    private DeathCtrl death;
    //Temp spot till i can find a better one 
    [SerializeField] public float PlayerHealth = 80;
    private float PlayerMaxHealth = 80;

    private void Awake()
    {
        player = this.GetComponent<PlayerCtrl>();
        death = this.GetComponent<DeathCtrl>();
    }

    [SerializeField] private GameObject health;
    [SerializeField] private GameObject stamina;
    [SerializeField] private GameObject mana;

    public void ChangeHealth(float amount)
    {
        health.transform.right += new Vector3(0, 0, amount);
        if(PlayerHealth <= PlayerMaxHealth)
        {
            PlayerHealth += amount * 20;
            PlayerHealth = Mathf.Ceil(PlayerHealth);
            PlayerHealth = Mathf.Clamp(PlayerHealth, 0, PlayerMaxHealth);
        }
        if(PlayerHealth <= 0)
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
