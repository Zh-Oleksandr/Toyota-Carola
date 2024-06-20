using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    public GameObject weapon;
    public int slotsize = 2;
    public Rigidbody2D rb;

    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition; ;
        angle = (mousePos.y - rb.transform.position.y) / (mousePos.x - rb.transform.position.y) * 180/Mathf.PI;
        Vector3 direction = new Vector3(0, 0, angle);

        rb.transform.rotation = Quaternion.Euler(direction);
       
    }
}
