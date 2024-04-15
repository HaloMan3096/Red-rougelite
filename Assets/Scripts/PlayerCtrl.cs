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

    #region Constants
    // we make a few const strings for the animator editor
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string LAST_HORIZONTAL = "LastHorizontal";
    private const string LAST_VERTICAL = "LastVertical";
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

        // Then we change the animator
        animator.SetFloat(HORIZONTAL, movement.x);
        animator.SetFloat(VERTICAL, movement.y);

        rotateAttackArea();

        if (movement != Vector2.zero)
        {
            animator.SetFloat(LAST_HORIZONTAL, movement.x);
            animator.SetFloat(LAST_VERTICAL, movement.y);
        }
    }

    private void rotateAttackArea()
    {
        float dirrection = 0;
        if (Mathf.Abs(InputManager.Movement.x) > Mathf.Abs(InputManager.Movement.y))
        {
            if (InputManager.Movement.x < 0)
            {
                dirrection = -90;
            }
            dirrection = 90;
        }
        if (Mathf.Abs(InputManager.Movement.x) < Mathf.Abs(InputManager.Movement.y))
        {
            if (InputManager.Movement.y < 0)
            {
                dirrection = 180;
            }
            dirrection = 0;
        }

        Debug.Log($"X:{InputManager.Movement.x}, Y:{InputManager.Movement.y}; " +
            $"Animator X:{animator.GetFloat("Horizontal")}, Y:{animator.GetFloat("Vertical")} " +
            $"LastAnimator X:{animator.GetFloat("LastHorizontal")}, Y:{animator.GetFloat("LastVertical")}");

        var rot = gameObject.transform.localRotation.eulerAngles;
        rot.Set(0f, 0f, dirrection);
        attackArea.transform.Rotate(rot);
    }
}
