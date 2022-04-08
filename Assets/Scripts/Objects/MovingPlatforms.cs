using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    public GameObject Player;

    public void OnTriggerEnter(Collider other)
    {
        Player.transform.parent = transform;
    }

    public void OnTriggerExit(Collider other)
    {
        Player.transform.parent = null;
    }
}
