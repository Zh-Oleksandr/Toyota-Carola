using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public UniversalMovement movement;
    public GameObject newhull = null;

    public float interactionradius = 1;

    void Start()
    {
        interactionradius = this.GetComponent<CircleCollider2D>().radius;
        movement = this.GetComponentInParent<UniversalMovement>();
        movement.Controller = this.gameObject;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Chasse")
        {
            newhull = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (newhull != null)
        {
            if (Vector3.Distance(this.transform.position, newhull.transform.position) > interactionradius)
            {
                newhull = null;
            }
        }     
    }

    void Update()
    {
        if (newhull != null)
        {
            if (Input.GetKey(KeyCode.F))
            {
                movement.Controller = null;
                movement = newhull.GetComponent<UniversalMovement>();
                movement.dead = false;
                this.gameObject.transform.SetParent(newhull.transform);
                movement.Controller = this.gameObject;
                newhull = null;
            }
        }
        if (movement.car == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                movement.CarMoveForeward();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                movement.CarMoveBackward();
            }
            else
            {
                movement.CarSlowDown();
            }
            if (Input.GetKey(KeyCode.D))
            {
                movement.CarMoveRight();
            }
            else if (Input.GetKey(KeyCode.A))
            {
                movement.CarMoveLeft();

            }
        }
    }
}
