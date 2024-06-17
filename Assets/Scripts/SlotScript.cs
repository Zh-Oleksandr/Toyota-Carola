using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    public GameObject weapon;
    public int slotsize = 2;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition; ;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        rb.transform.rotation = Quaternion.LookRotation(direction);
       
    }
}
