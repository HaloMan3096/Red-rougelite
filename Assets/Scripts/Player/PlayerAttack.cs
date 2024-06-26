using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool isAttacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    private Animator animator;

    private PlayerCtrl player;
    // get the attack area game object at run time
    private void Start()
    {
        player = GetComponent<PlayerCtrl>();
        attackArea = transform.GetChild(0).gameObject;
        animator = GetComponent<Animator>();
    }

    // Check for the input for attack
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        // if isAttacking is true then we want to only leave it for the timeToAttack float
        if (isAttacking)
        {
            timer += Time.deltaTime;

            if (Input.GetKey(KeyCode.V))
            {
                animator.SetTrigger("Attack_Again");
                timer = 0;
            }

            if (timer >= timeToAttack )
            {
                timer = 0f;
                isAttacking = false;
                attackArea.SetActive(isAttacking);
                animator.ResetTrigger("Attack");
                animator.ResetTrigger("Attack_Again");
                player.Attack(false);
            }
        }
    }

    // Change the bool isAttacking to true
    private void Attack()
    {
        player.Attack(true);
        isAttacking = true;
        attackArea.SetActive(isAttacking);
        animator.SetTrigger("Attack");
    }
}
