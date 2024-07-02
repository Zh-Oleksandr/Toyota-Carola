using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{

    public GameObject equipment;

    public ChasseScript originchasse;

    public GameObject slotgraphic;

    public GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < originchasse.Slots.Length; i++) 
        {
            Instantiate(equipment, slotgraphic.transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
