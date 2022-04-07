using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    public Animator myChest = null;
    
    public void ChestOpen()
    {
        myChest.Play("ChestOpen", 0, 0.0F);
    }
    public void ChestClosed()
    {
        myChest.Play("ChestClosed", 0, 0.0F);
    }
}
