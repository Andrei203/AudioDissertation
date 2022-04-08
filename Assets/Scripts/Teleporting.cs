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
      if (ignore || other.gameObject != player) return;
      StartCoroutine(Teleport());
   }

   private void OnTriggerExit(Collider other)
   {
      ignore = false;
   }

   IEnumerator Teleport()
          {
             //yield return new WaitForSeconds(1);
             if (teleport == null) yield break;
             //player.transform.position = teleport.transform.position;
             player.transform.position += teleport.transform.position - transform.position;
             teleport.ignore = true;
             yield return null;
          }
}
