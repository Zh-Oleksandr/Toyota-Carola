using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public UniversalMovement movement;
    // Start is called before the first frame update
    void Start()
    {
        movement = this.GetComponentInParent<UniversalMovement>();
    }

    // Update is called once per frame
    void Update()
    {
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
