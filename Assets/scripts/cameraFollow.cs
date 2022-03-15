using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float timeOffset;
    public Vector3 initialCameraPosition;

    public Vector3 positionOffSet;
    public Quaternion rotationOffSet;

    public Vector3 position0 = new Vector3(0, 7, 0);
    public Quaternion rotation0 = Quaternion.Euler(45, 0, 0);
    public int cameraNum = 1;

    public Vector3 position1 = new Vector3(0, 5, 0);
    public Quaternion rotation1 = Quaternion.Euler(35, 0, 0);

    public Vector3 position2 = new Vector3(0, 3, 0);
    public Quaternion rotation2 = Quaternion.Euler(25, 0, 0);

    private Vector3 velocity;
    private float Velocity = 0.0f;

    void Start()
    {
        positionOffSet = position1;
        rotationOffSet = rotation1;
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire3"))
        {
            if(cameraNum < 2)
            {
                cameraNum ++;
                if(cameraNum == 1)
                {
                    positionOffSet = position1;
                    rotationOffSet = rotation1;
                }else if(cameraNum == 2)
                {
                    positionOffSet = position2;
                    rotationOffSet = rotation2;
                }
            }else
            {
                cameraNum = 0;
                positionOffSet = position0;
                rotationOffSet = rotation0;
            }
        }

        transform.position = Vector3.SmoothDamp(transform.position, initialCameraPosition, ref velocity, timeOffset);
        initialCameraPosition = move_player.instance.transform.position + positionOffSet - new Vector3(0, 0, 6);
        float yRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationOffSet.eulerAngles.y, ref Velocity, timeOffset);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
    }
}

