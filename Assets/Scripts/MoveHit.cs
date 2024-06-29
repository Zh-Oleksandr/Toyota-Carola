using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class MoveHit : MonoBehaviour
{





    public float Range = 50;
    private float timer = 0;



    public Rigidbody2D rb;
    public float maxspeed = 10f;
    public float speed = 10f;
    public float accel = 3f;
    public float turnspeed = Mathf.PI * 1 / 3;

    public float deccel = 3f;

    private Vector2 movedirection;
    private float angle = Mathf.PI * 1 / 2;



    public SlotScript turret;







    public void RoundMoveForeward()
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
    public void RoundMoveBackward()
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

    public void RoundMoveRight()
    {
        angle -= turnspeed * Time.deltaTime;
    }
    public void RoundMoveLeft()
    {
        angle += turnspeed * Time.deltaTime;
    }

    public void RoundSlowDown()
    {

        if (speed > 0)
        {
            speed -= deccel * Time.deltaTime;
        }
        else if (speed < 0)
        {
            speed += deccel * Time.deltaTime;
        }
        if (Mathf.Abs(speed - 0) <= 0.005)
        {
            speed = 0;
        }
    }















    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        angle = turret.angle;
    }

    // Update is called once per frame
    void Update()
    {



        Vector3 rotationvector = new Vector3(0, 0, angle * 180 / Mathf.PI);
        Quaternion rotation = Quaternion.Euler(rotationvector);
        rb.transform.rotation = rotation;
        movedirection = new Vector3(1 * Mathf.Cos(angle), 1 * Mathf.Sin(angle));








        rb.velocity = movedirection * speed;









        if (timer < Range/speed)
        {
            timer += Time.deltaTime;
        }
        else
        {
            print("bullet gone");
            Destroy(this.gameObject);
        }



    }
}
