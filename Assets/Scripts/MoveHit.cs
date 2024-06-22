using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHit : MonoBehaviour
{

    public float moveSpeed = 5;
    public float Range = 50;
    private float timer = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




        transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;



        if (timer < Range)
        {
            timer += Time.deltaTime;
        }
        else
        {
            print("bullet gone");
            Destroy(gameObject);
        }



    }
}
