using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

public class water : MonoBehaviour
{
    public Canvas Water_Control_Canvas;
    public Canvas Sterowanie_Mobilne;
    public bool czywoda;
    public float speed = 4;
    public float moveSpeed;
    public zakladanie_maski koks;
    // Use this for initialization
    void Start()
    {
        Water_Control_Canvas.enabled = false;
        Sterowanie_Mobilne.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            czywoda = true;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (czywoda == true)
        {
            Water_Control_Canvas.enabled = true;
            Sterowanie_Mobilne.enabled = false;
        }

        if (other.tag == "Player" && CrossPlatformInputManager.GetButton("Jump"))
        {
            other.SendMessageUpwards("Za", true);
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }

        else if (other.tag == "Player" && CrossPlatformInputManager.GetButton("Crouch"))
        {
            other.SendMessageUpwards("Za", true);
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        else if ((other.tag == "Player" && CrossPlatformInputManager.GetButton("Lewo")))
        {
            other.SendMessageUpwards("Za", true);
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 1);
        }
        else if ((other.tag == "Player" && CrossPlatformInputManager.GetButton("Prawo")))
        {
            other.SendMessageUpwards("Za", true);
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 1);
        }
        else
        {
            other.SendMessageUpwards("Za", true);
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessageUpwards("Za", false);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            czywoda = false;
            Water_Control_Canvas.enabled = false;
            Sterowanie_Mobilne.enabled = true;
        }
    }
}