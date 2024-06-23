using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCannonScript : MonoBehaviour
{
    public int size = 2;
    public GameObject bullet;
    public void Fire()
    {
  
        print("bang");

       Instantiate(bullet);

    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponentInParent<UniversalMovement>().notai == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Fire();
            }
        }
    }
}
