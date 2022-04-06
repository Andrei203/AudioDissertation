using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
   [SerializeField] private Teleporting teleport;
   [SerializeField] private GameObject player;

   public bool ignore = false;

   private void OnTriggerEnter(Collider other)
   {
      if (ignore) return;
      StartCoroutine(Teleport());
   }

   private void OnTriggerExit(Collider other)
   {
      ignore = false;
   }

   IEnumerator Teleport()
          {
             yield return new WaitForSeconds(1);
             var position = teleport.transform.position;
             player.transform.position = new Vector3(position.x,
                position.y, position.z);
             teleport.ignore = true;
          }
}
