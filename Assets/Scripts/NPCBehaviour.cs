using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    public GameObject Player;
    public float AllowedDistance;
    public float minDist;
    public float followSpeed; 
    public float pushRate;
    void Update()
    {
        transform.LookAt(Player.transform);
        float TargetDistance = (Player.transform.position - transform.position).magnitude;
        if (TargetDistance < AllowedDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, followSpeed * Time.deltaTime);
        }
        
        if (TargetDistance < minDist)
        {
            
            Vector3 dir = (Player.transform.position - this.transform.position);
            Player.GetComponent<Rigidbody>().AddForce(dir * pushRate, ForceMode.Impulse); 
        }
    }
}
