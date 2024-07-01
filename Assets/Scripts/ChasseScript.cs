using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ChasseScript : MonoBehaviour
{
    public GameObject[] Slots;
    public Vector3[] slotpos;

    public GameObject thisgameobject;
    public UniversalMovement universalMovement;
    public GameObject inventory;


    public GameObject inventorycheck;
    public bool inventoryopen = false;

    // Start is called before the first frame update
    void Start()
    {
        thisgameobject = this.gameObject;
        universalMovement = this.GetComponent<UniversalMovement>();
        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i].transform.position = this.GetComponentInParent<Transform>().position + slotpos[i];
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && universalMovement.notai == true && this.GetComponentInChildren<PlayerControllerScript>().inventoryopen == false)
        {
            if (!inventoryopen)
            {
                inventoryopen = true;
                inventorycheck = Instantiate(inventory, this.transform.position - new Vector3(5f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
                inventorycheck.GetComponent<InventoryScript>().originchasse = this;
            }
            else
            {
                if(inventorycheck != null)
                {
                    Destroy(inventorycheck);
                    inventoryopen = false;
                }
            }
        }
        if (inventoryopen)
        {
            inventorycheck.transform.position = new Vector3(this.transform.position.x - 5, this.transform.position.y, this.transform.position.z);
        }
    }
}
