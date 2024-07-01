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
    public float speed = 10f;
    public float angle = 0f;








    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        angle = transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector3(Mathf.Cos(angle * Mathf.PI / 180), Mathf.Sin(angle * Mathf.PI / 180), 0) * speed;




        if (timer < Range/speed)
        {
            timer += Time.deltaTime;
        }
        else
        {
            print("bullet gone");
            Destroy(this);
        }



    }
}
