using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public int nothing;
    private Vector3 FirstPosition;
    public Rigidbody rb;
    public bool falling = false;
    public int norme=1;
    public static FallingPlatform instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance of health_manager");
            return;
        }

        instance = this;
    }

    void Start()
    {
        FirstPosition = transform.position;
    }

    void Update()
    {
        if(falling)
        {
            norme=1;
            transform.Translate(Vector3.down* 15 * norme * Time.deltaTime);
        }
        

        if(health_manager.instance.lose){
            transform.position=FirstPosition;
            falling=false;
            norme=0;
        }
    }

void OnCollisionEnter(Collision other){
    StartCoroutine(Falling());         
}   


IEnumerator Falling()
    {
        yield return new WaitForSeconds(0.5f);
        falling = true;
    }
}

