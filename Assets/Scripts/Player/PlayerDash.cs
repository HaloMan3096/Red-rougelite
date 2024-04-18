using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private DashState dashState = DashState.Ready;
    [SerializeField] private float dashSpeed = 10f;
    private PlayerCtrl Ctrl;
    private float dashTimer;
    private float maxDash = 20f;

    private float originalSpeed;

    void Start()
    {
        Ctrl = GetComponent<PlayerCtrl>();
    }

    void Update()
    {
        switch (dashState)
        {
            case DashState.Ready:
                if (Input.GetKeyDown(KeyCode.J))
                {
                    originalSpeed = Ctrl.moveSpeed;
                    Ctrl.changeSpeed(dashSpeed);
                    dashState = DashState.Dashing;
                }
                break;

            case DashState.Dashing:
                dashTimer += Time.deltaTime * 5;
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    Ctrl.changeSpeed(originalSpeed);
                    dashState = DashState.CoolDown;
                }
                break;

            case DashState.CoolDown:
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }
    }

    private Vector2 GetDirection()
    {
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
        return dirrection;
    }
}

public enum DashState
{
    Ready,
    Dashing,
    CoolDown
}