using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCannonScript : MonoBehaviour
{
    public int size = 2;
    public GameObject bullet;
    public Rigidbody2D rb;
    public void Fire()
    {
        print("bang");
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
