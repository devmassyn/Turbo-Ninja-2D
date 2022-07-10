using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class ladder : MonoBehaviour
{
    public float speed = 6;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && CrossPlatformInputManager.GetButton("Jump"))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

        }
        else if (other.tag == "Player" && CrossPlatformInputManager.GetButton("Crouch"))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);

        }
        else
        {

            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);

        }
    }
}