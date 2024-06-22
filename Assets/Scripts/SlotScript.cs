using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    public GameObject weapon;
    public int slotsize = 2;

    [SerializeField]
    private float xdis;
    [SerializeField]
    private float ydis;
    [SerializeField]
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousPos =  Input.mousePosition;
        Vector3 Mouse = Camera.main.ScreenToWorldPoint(MousPos);
        xdis = Mouse.x - this.transform.position.x;
        ydis = Mouse.y - this.transform .position.y;

        angle = Mathf.Atan(ydis/xdis) * 180/Mathf.PI;
        if (this.GetComponentInParent<UniversalMovement>().notai == true)
        {
            if (xdis < 0)
            {
                Vector3 direction = new Vector3(0, 0, 180 + angle);
                Quaternion rotation = Quaternion.Euler(direction);
                this.transform.rotation = rotation;
            }
            else
            {
                Vector3 direction = new Vector3(0, 0, angle);
                Quaternion rotation = Quaternion.Euler(direction);
                this.transform.rotation = rotation;
            }
        }
            
        
       
    }
}
