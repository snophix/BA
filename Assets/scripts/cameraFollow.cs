using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float timeOffset;
    public Vector3 initialCameraPosition;

    private Vector3 velocity;
    void Update()
    {
        initialCameraPosition = move_player.instance.transform.position + new Vector3(0, 5, 0) - new Vector3(0, 0, 6);
        transform.position = Vector3.SmoothDamp(transform.position, initialCameraPosition, ref velocity, timeOffset);
    }
}

