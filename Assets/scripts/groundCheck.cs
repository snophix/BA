using UnityEngine;

public class groundCheck : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Platform")
        {
            move_player.instance.isGrounded = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Platform")
        {
            move_player.instance.isGrounded = false;
        }
    }
}