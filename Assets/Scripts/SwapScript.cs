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
}
