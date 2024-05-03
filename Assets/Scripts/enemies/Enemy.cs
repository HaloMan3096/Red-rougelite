using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private EnemyData data;
    [SerializeField] private GameObject Gem;
    [SerializeField] private int HowMany = 1;

    private void Start()
    {
        SetEnemyValues();
    }

    private void SetEnemyValues()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Health>() != null)
            {
                collision.GetComponent<Health>().Damage(damage);
                this.GetComponent<Health>().Damage(10000);
            }
        }
    }

    private void OnDestroy()
    {
        Debug.Log($"{this} died and gotHit: {GetComponent<Health>().gotHit}");
        if (GetComponent<Health>().gotHit)
        {
            for (int i = 0; i < HowMany; i++)
            {
                Debug.Log($"Gems Dropped");
                GameObject.Instantiate(Gem, GameObject.FindGameObjectWithTag("Interact").transform);
            }
        } 
    }
}
