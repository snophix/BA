using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int curaliumCount;

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance of Inventory");
            return;
        }

        instance = this;
    }
    public void AddCuralium(int amount)
    {
        curaliumCount += amount;
    }
}
