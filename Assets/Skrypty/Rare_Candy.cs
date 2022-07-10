using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Rare_Candy : MonoBehaviour
{
    public bool czyPodniesiony=false;
    private bool wZasiegu;
    private Collider2D Player;
    private bool obrot;
    private Rigidbody2D Candy;
    public float hor, ver;
    private CharacterController2D skrypt;
    private BoxCollider2D box;
    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        Candy = GetComponent<Rigidbody2D>();
        skrypt = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        box.enabled = false;
    }
    private void Update()
    {
        if (wZasiegu==true&&CrossPlatformInputManager.GetButtonDown("Sklep"))
        {
            if(czyPodniesiony)
            {
                transform.parent = null;
                czyPodniesiony = false;
                obrot = skrypt.m_FacingRight;
                if (obrot == true)
                {
                    Candy.velocity = new Vector2(hor, ver);
                    Candy.bodyType=RigidbodyType2D.Dynamic ;
                    box.enabled = true;
                }
                else
                {
                    Candy.velocity = new Vector2(-hor, ver);
                    Candy.bodyType = RigidbodyType2D.Dynamic;
                    box.enabled=true;
                }
            }
            else
            {
                box.enabled = false;
                transform.parent = Player.transform;
                czyPodniesiony = true;
                transform.localPosition = new Vector2(0.32f, -0.038f);
                Candy.bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            wZasiegu = true;
            Player = other;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            wZasiegu = false;
        }
    }
}
