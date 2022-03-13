using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curalium : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            Inventory.instance.AddCuralium(1);
            Destroy(gameObject);
        }
    }
}
