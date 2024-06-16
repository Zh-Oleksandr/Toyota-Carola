using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

public class UniversalMovement : MonoBehaviour
{
    public GameObject Controller;

    public bool car = true;
    public bool tank = false;
    public bool other = false;

    public bool dead = false;

    public Rigidbody2D rb;
    public float maxspeed = 10f;
    public float speed = 0f;
    public float accel = 3f;
    public float turnspeed = Mathf.PI * 1 / 3;


    public float deccel = 3f;

    private Vector2 movedirection;
    private float angle = Mathf.PI * 1/2;
    public void CarMoveForeward()
    {
        if (speed < 0)
        {
            speed += (accel + deccel) * Time.deltaTime;
        }
        else if (speed < maxspeed)
        {
            speed += accel * Time.deltaTime;
        }
    }
    public void CarMoveBackward()
    {
        if (speed > 0)
        {
            speed -= (accel + deccel) * Time.deltaTime;
        }
        else if (Mathf.Abs(speed) < maxspeed)
        {
            speed -= accel * Time.deltaTime;
        }
    }

    public void CarMoveRight()
    {
        if (speed > 0)
        {
            angle -= turnspeed * Time.deltaTime;
        }
        else if (speed < 0)
        {
            angle += turnspeed * Time.deltaTime;
        }
    }
    public void CarMoveLeft()
    {
        if (speed > 0)
        {
            angle += turnspeed * Time.deltaTime;
        }
        else if (speed < 0)
        {
            angle -= turnspeed * Time.deltaTime;
        }
    }

    public void CarSlowDown()
    {

        if (speed > 0)
        {
            speed -= deccel * Time.deltaTime;
        }
        else if (speed < 0)
        {
            speed += deccel * Time.deltaTime;
        }
        if(Mathf.Abs(speed - 0) <= 0.005)
        {
            speed = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller == null)
        {
            dead = true;
        }
        if (dead == true && Controller != null)
        {
            Destroy(Controller);
        }
        if (dead && speed != 0)
        {
            if (Mathf.Abs(speed) <= 0.05)
            {
                speed = 0;
            }
            else if(speed > 0)
            {
                speed -= deccel * Time.deltaTime;
            }
            else if(speed < 0)
            {
                speed += deccel * Time.deltaTime;
            }
            
        }
        Vector3 rotationvector = new Vector3(0, 0, angle * 180/Mathf.PI);
        Quaternion rotation = Quaternion.Euler(rotationvector);
        rb.transform.rotation = rotation;
        movedirection = new Vector3(1 * Mathf.Cos(angle), 1 * Mathf.Sin(angle));
        if (car)
        {
            tank = false;
            other = false;
            rb.velocity = movedirection * speed;

        }
        else if (tank)
        {
            car = false;
            other = false;
            rb.velocity = movedirection * speed;
        }
        else if (other)
        {
            car = false;
            tank = false;
        }
        
    }
}
