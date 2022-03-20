using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSystem : MonoBehaviour
{
    public string LevelName;

    private void OnTriggerEnter(Collider collider)
    {
        // petit commentiare de teste
        if(collider.tag == "Player")
        {
            LoadSpecificLevel.instance.LoadLevel(LevelName);
        }
    }
}
