using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_spawn : MonoBehaviour
{
    public static Player_spawn instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance of Player_spawn");
            return;
        }

        instance = this;
    }

    void Start()
    {
        move_player.instance.transform.position = transform.position;
    }
}
