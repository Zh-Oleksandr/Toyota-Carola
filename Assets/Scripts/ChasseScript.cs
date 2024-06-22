using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ChasseScript : MonoBehaviour
{
    public GameObject[] Slots;
    public Vector3[] slotpos;

    public GameObject frontarmor;
    public GameObject backarmor;
    public GameObject sidearmor;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i].transform.position = this.GetComponentInParent<Transform>().position + slotpos[i];
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
