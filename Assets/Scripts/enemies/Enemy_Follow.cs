using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float agroDist;

    private float distance;

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance !< agroDist)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed);
        }
    }
}
