using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private Vector2 dashSpeed = new Vector2(10, 10);

    PlayerCtrl playerCtrl;
    Rigidbody2D rb;
    Animator animator;
    bool isDashing;
    
    void Start()
    {
        playerCtrl = GetComponent<PlayerCtrl>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Dashin Here");
            dashMovement();
        }
    }

    /// <summary>
    /// Figure out dirrection then push the rb in that direction
    /// </summary>
    public void dashMovement()
    {
        animator.SetTrigger("Dash");
        isDashing = true;

        Vector2 dirrection = new Vector2(0, 0);
        if (Mathf.Abs(InputManager.Movement.x) > Mathf.Abs(InputManager.Movement.y))
        {
            // Check if x is negitive
            if (InputManager.Movement.x < 0)
            {
                dirrection = new Vector2(-10, 0);
            }
            else
            {
                dirrection = new Vector2(10, 0);
            }
        }
        if (Mathf.Abs(InputManager.Movement.x) < Mathf.Abs(InputManager.Movement.y))
        {
            // Check if y is negitive
            if (InputManager.Movement.y < 0)
            {
                dirrection = new Vector2(0, -10);
            }
            else
            {
                dirrection = new Vector2(0, 10);
            }
        }

        rb.velocity = (dirrection * dashSpeed);
    }
}
