using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class camerascript : MonoBehaviour
{
    public bool cameraincorrectpos = true;
    public void CameraReset()
    {
        this.transform.position = Vector3.zero;
        this.transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, -10f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        if (this.GetComponentInParent<ChasseScript>().inventoryopen)
        {
            cameraincorrectpos = false;
            this.transform.position = new Vector3(this.GetComponentInParent<ChasseScript>().inventorycheck.transform.position.x + 5, this.GetComponentInParent<ChasseScript>().inventorycheck.transform.position.y,-10f);
        }
        else
        {
            cameraincorrectpos = true;
        }
        if (cameraincorrectpos && this.transform.position != new Vector3(transform.parent.position.x, transform.parent.position.y, -10f))
        {
            CameraReset();
            print("reset");
        }
    }
}
