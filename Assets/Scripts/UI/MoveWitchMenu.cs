using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWitchMenu : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] Vector3[] locations;
    [SerializeField] Vector3 speed = new Vector3(1, 0, 0);

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Running", true);
    }

    private void Update()
    {
        if(this.gameObject.transform.localPosition.x >= 1920)
        {
            ReturnWitch();
        }
        else
        {
            MoveWitch();
        }
    }

    private void MoveWitch()
    {
        this.gameObject.transform.localPosition += speed;
    }

    private void ReturnWitch()
    {
        switch (Random.Range(00,05))
        {
            case 0:
                if(speed.x !>= 3)
                    this.speed += new Vector3(1, 0, 0);
                this.gameObject.transform.localPosition = locations[1];
                break;
            case 1:
                if (speed.x! <= 0)
                    this.speed.x -= 1;
                this.gameObject.transform.localPosition = locations[2];
                break;
            case 2:
                this.gameObject.transform.localPosition = locations[3];
                break;
            case 3:
                if (speed.x! <= 0)
                    this.speed.x -= 1;
                this.gameObject.transform.localPosition = locations[4];
                break;
            case 4:
                this.gameObject.transform.localPosition = locations[5];
                break;
            case 5:
                if (speed.x! >= 3)
                    this.speed += new Vector3(1, 0, 0);
                this.gameObject.transform.localPosition = locations[6];
                break;
        }
        Debug.Log($"Witch Location: {this.gameObject.transform.localPosition}");   
    }
}
