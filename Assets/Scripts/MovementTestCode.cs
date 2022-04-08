using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.UIElements;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MovementTestCode : MonoBehaviour
{

   public float speed;
   public void Update()
   {
      float xDirection = Input.GetAxis("Horizontal");
      float zDirection = Input.GetAxis("Vertical");


      Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
      
      transform.position += moveDirection * (speed * Time.deltaTime);
   }
}
