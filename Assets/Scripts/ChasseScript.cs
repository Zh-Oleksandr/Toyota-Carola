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

    public GameObject frontarmor;
    public GameObject backarmor;
    public GameObject leftarmor;
    public GameObject rightarmor;

    public GameObject inventorycheck;
    private bool inventoryopen = false;

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
        if (Input.GetKeyDown(KeyCode.I) && universalMovement.notai == true)
        {
            if (!inventoryopen)
            {
                inventoryopen = true;
                inventorycheck = Instantiate(inventory, this.transform.position - new Vector3(1f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
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
    }
}
