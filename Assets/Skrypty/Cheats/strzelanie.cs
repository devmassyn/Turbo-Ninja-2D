using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class strzelanie : MonoBehaviour
{
    public float Throw_attackCoolDown = 1f;
    private bool Throw_attacking = false;
    private float Throw_attacktime = 0;
    private bool timer_throw;
    public GameObject Bullet;
    private GameObject Throw;
    public GameObject opaska;
    public GameObject Ak;
    private GameObject gracz;
    public Transform fire_point;
    public float ver, hor;
    public bool ak;
    public bool obrot;
    private AudioSource source;
    public AudioClip AkSound;
    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        Ak.SetActive(false);
        opaska.SetActive(false);
        gracz = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Ak.SetActive(gracz.GetComponent<PlayerAttack>().ak);
        opaska.SetActive(gracz.GetComponent<PlayerAttack>().ak);
        if (gracz.GetComponent<PlayerAttack>().ak)
        {           
                if (timer_throw)
                {
                    if (CrossPlatformInputManager.GetButton("Throw") && !Throw_attacking)
                    {
                        Throw = (GameObject)Instantiate(Bullet, fire_point.position, transform.rotation);
                        obrot = gracz.GetComponent<CharacterController2D>().m_FacingRight;
                        if (obrot == true)
                        {
                            Throw.GetComponent<Rigidbody2D>().velocity = new Vector2(hor, ver);
                        }
                        else
                        {
                            Throw.GetComponent<Rigidbody2D>().velocity = new Vector2(-hor, ver);
                        }
                        source.PlayOneShot(AkSound, 1);
                        Throw_attacking = true;
                        timer_throw = false;
                        Throw_attacktime = Throw_attackCoolDown;
                    }

                }
                else
                {
                    if (Throw_attacktime > 0)
                    {
                        Throw_attacktime -= Time.deltaTime;
                    }
                    else
                    {
                        timer_throw = true;
                        Throw_attacking = false;
                    }
                }
            

        }
        if (gracz.GetComponent<PlayerMovement>().crouch)
        {
            transform.localPosition = new Vector2(0, -0.1f);
        }
        else
        {
            transform.localPosition = new Vector2(0, 0);
        }
    }
}
