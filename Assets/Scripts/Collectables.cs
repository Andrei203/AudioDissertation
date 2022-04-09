using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            Destroy(gameObject);
        }
}
