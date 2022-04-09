using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
   public int enemyHealth;

   public void enemyHit(int damage)
   {
      enemyHealth -= damage;
      Debug.Log("health" + enemyHealth);
   }

}
