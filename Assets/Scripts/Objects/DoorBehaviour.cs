using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Animator myDoor = null;
    
    public void OpenDoor()
    {
        myDoor.Play("DoorOpen", 0, 0.0F);
    }
    public void CloseDoor()
    {
        myDoor.Play("DoorClosed", 0, 0.0F);
    }
}
