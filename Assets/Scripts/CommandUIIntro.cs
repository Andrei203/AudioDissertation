using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandUIIntro : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject uiObject;
    
    void Start()
    {
     uiObject.SetActive(false);   
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            uiObject.gameObject.SetActive(true);
           // StartCoroutine("WaitForSec");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        uiObject.gameObject.SetActive(false);
    }
}
