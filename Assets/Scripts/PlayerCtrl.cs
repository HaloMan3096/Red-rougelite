using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    /// <summary>
    /// Changes the Animator and moves the player
    /// </summary>
  
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    private GameObject attackArea;

    private bool isDashing = false;
    private float timeToDash = 1f;
    [SerializeField] private float timer = 0f;

    #region Constants
    // we make a few const strings for the animator editor
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string LAST_HORIZONTAL = "LastHorizontal";
    private const string LAST_VERTICAL = "LastVertical";
    private const string DASH = "Dash";
    #endregion

    // on awake we get the rigidbody and animator
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        attackArea = transform.GetChild(0).gameObject;
    }

    // checking for movement then adding it to the rigid body velocity
    private void Update()
    {
        movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        rb.velocity = movement * moveSpeed;

        if (isDashing)
        {
            timer += Time.deltaTime;

            if (timer >= timeToDash)
            {
                timer = 0f;
                isDashing = false;
                animator.ResetTrigger(DASH);
            }
        }

        // Then we change the animator
        animator.SetFloat(HORIZONTAL, movement.x);
        animator.SetFloat(VERTICAL, movement.y);

        rotateAttackArea();

        if (movement != Vector2.zero)
        {
            animator.SetFloat(LAST_HORIZONTAL, movement.x);
            animator.SetFloat(LAST_VERTICAL, movement.y);
        }
        animator.ResetTrigger(DASH);
    }

    private void rotateAttackArea()
    {
        float dirrection = 0;
        if (Mathf.Abs(InputManager.Movement.x) > Mathf.Abs(InputManager.Movement.y))
        {
            // Check if x is negitive
            if (InputManager.Movement.x < 0)
            {
                dirrection = 180;
            }
            else
            {
                dirrection = 0;
            }
        }
        if (Mathf.Abs(InputManager.Movement.x) < Mathf.Abs(InputManager.Movement.y))
        {
            // Check if y is negitive
            if (InputManager.Movement.y < 0)
            {
                dirrection = -90;
            }
            else
            {
                dirrection = 90;
            }
        }

        // detect if we are moving the player
        if (Mathf.Abs(InputManager.Movement.x) >= 1 || Mathf.Abs(InputManager.Movement.y) >= 1)
        {
            attackArea.transform.rotation = Quaternion.Euler(0, 0, dirrection);
        }
    }
}
