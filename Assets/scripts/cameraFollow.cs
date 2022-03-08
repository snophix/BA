using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = move_player.instance.transform.position + new Vector3(0, 5, 0) - new Vector3(0, 0, 6);
    }
}
