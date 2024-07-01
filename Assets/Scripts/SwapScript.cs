using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapScript : MonoBehaviour
{
    public PlayerControllerScript playerControllerScript;

    public void Swap()
    {
        playerControllerScript.Swap();
    }
    public void InventoryOpen()
    {
        if (playerControllerScript.inventoryopen == false)
        {
            playerControllerScript.WeaponSwap();
        }
        else
        {
            playerControllerScript.inventoryopen = false;
            playerControllerScript.GetComponentInParent<ChasseScript>().inventoryopen = false;
            Destroy(playerControllerScript.otherinventory);
            Destroy(playerControllerScript.thisinventory);
        }
        
    }

}
