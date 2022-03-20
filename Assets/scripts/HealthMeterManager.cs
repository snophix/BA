
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMeterManager : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        animator.SetInteger("Health", health_manager.instance.health);
    }
}
