using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    public GameObject Player;
    public float AllowedDistance = 5;
    public float followSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);
        float TargetDistance = (Player.transform.position - transform.position).magnitude;
        if (TargetDistance < AllowedDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, followSpeed * Time.deltaTime);
        }
    }
}
