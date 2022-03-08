using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Collider ckeckpointCollider;

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            Player_spawn.instance.transform.position = transform.position;
            ckeckpointCollider.enabled = false;
        }
    }
}