using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Animator myDoor = null;

    public bool openDoorTrigger = false;

    public bool closeDoorTrigger = false;
    private void OnTriggerEnter(Collider other)
    {
        /*if(other.CompareTag("Player"))
        {
            if(openDoorTrigger)
            {
                myDoor.Play("DoorOpen", 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if(closeDoorTrigger)
            {
                myDoor.Play("DoorClosed", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }*/
    }

    public void OpenDoor()
    {
        myDoor.Play("DoorOpen", 0, 0.0f);
    }
    public void CloseDoor()
    {
        myDoor.Play("DoorClosed", 0, 0.0F);
    }
}
