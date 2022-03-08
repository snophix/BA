using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_manager : MonoBehaviour
{
    public int max_health = 4;
    public int health;
    public bool lose;

    public Animator FadeInAnimation;
    public Animator Health;

    public static health_manager instance;

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
        health = max_health;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            Damage();
        }
        if(Input.GetButtonDown("Fire3"))
        {
            Cure();
        }
        
        if(health < 0)
        {
            //StartCoroutine(ReplacePlayer());
            health = max_health;
        }
    }
    public void Damage()
    {
        if(health > 0)
        {
            health --;
        }
        // if(health == 0)
        // {
        //     StartCoroutine(ReplacePlayer());
        //     health = max_health;
        // }
    }
    public void Cure()
    {
        if(health < max_health)
            {
                health++;
            }
    }
    public void Respawn()
    {
        StartCoroutine(ReplacePlayer());       
    }

    private IEnumerator ReplacePlayer()
    {
        FadeInAnimation.SetTrigger("FadeIn");
        lose=true;
        yield return new WaitForSeconds(1f);
        transform.position = Player_spawn.instance.transform.position;
        health--;
        lose=false;
    }
}
