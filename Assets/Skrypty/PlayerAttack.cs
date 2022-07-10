using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerAttack : MonoBehaviour
{
    [Header("Mele")]
    private bool Mele_attacking = false;
    private float Mele_attackTimer = 0;
    public float Mele_attackDuration = 0f;
    public float Mele_attackCoolDown = 1f;
    private float Mele_attacktime = 0;
    private bool timer_mele;
    public Collider2D Mele_attackTrigger;

    [Header("Throw")]
    public float Throw_attackCoolDown = 1f;
    private bool Throw_attacking = false;
    private float Throw_attacktime = 0;
    private bool timer_throw;
    public GameObject Throw_attackTrigger;
    public Rigidbody2D shuriken;
    public int ile_shurikenow;
    public GameObject Throwable;
    private GameObject Throw;
    public float ver, hor;
    public bool ak;
    [Header("Dash")]
    public Image DashIcon;    
    public float dash_speed;
    private float dash_time;
    public float start_dash_time;
    private bool is_dashing;
    public GameObject bariera;
    public GameObject dash_effect;
    public float dash_cooldown;
    private float dash_timer;
    private Rigidbody2D rb;
    [Header("Inne")]
    private bool czyZaliczony;
    private int levelNumber;
    private Animator animator;
    public CharacterController2D skrypt;
    private bool obrot;
    private AudioSource source;
    public AudioClip MeleSound, ShurikenSound, DashSound;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        DashIcon.fillAmount = 0;    
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        is_dashing = false;
        bariera.SetActive(false);
        czyZaliczony = SaveSystem.GetBool("czyZaliczony" + (levelNumber - 1));
        if (czyZaliczony)
        {
            ile_shurikenow = SaveSystem.GetInt("ile_shurikenow" + (levelNumber - 1));
        }
        else
        {
            ile_shurikenow = 3;
        }
    }
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        Mele_attackTrigger.enabled = false;
        Throw_attackTrigger.SetActive(false);
        timer_mele = true;
   }
    private void Update()
    {
        if (timer_mele == true)
        {
            if (CrossPlatformInputManager.GetButtonDown("Attack") && !Mele_attacking)
            {
                Mele_attacking = true;
                Mele_attackTimer = Mele_attackDuration;
                Mele_attackTrigger.enabled = true;
                source.PlayOneShot(MeleSound, 1);
            }
            if (Mele_attacking)
            {
                if (Mele_attackTimer > 0)
                {
                    Mele_attackTimer -= Time.deltaTime;
                }
                else
                {
                    Mele_attacking = false;
                    Mele_attackTrigger.enabled = false;
                    timer_mele = false;
                    Mele_attacktime = Mele_attackCoolDown;
                }
            }

        }
        else
        {
            if (Mele_attacktime > 0)
            {
                Mele_attacktime -= Time.deltaTime;
            }
            else
            {
                timer_mele = true;
            }
        }
        if (!ak)
        {
            if (ile_shurikenow > 0)
            {
                if (timer_throw)
                {
                    if (CrossPlatformInputManager.GetButtonDown("Throw") && !Throw_attacking)
                    {
                        Throw = (GameObject)Instantiate(Throwable, transform.position, transform.rotation);
                        obrot = skrypt.GetComponent<CharacterController2D>().m_FacingRight;
                        if (obrot == true)
                        {
                            Throw.GetComponent<Rigidbody2D>().velocity = new Vector2(hor, ver);
                        }
                        else
                        {
                            Throw.GetComponent<Rigidbody2D>().velocity = new Vector2(-hor, ver);
                        }
                        source.PlayOneShot(ShurikenSound, 1);
                        Throw_attacking = true;
                        timer_throw = false;
                        Throw_attacktime = Throw_attackCoolDown;
                        ile_shurikenow--;
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

        }

        if (dash_timer <= 0)
        {
            if (is_dashing == false)
            {
                if (CrossPlatformInputManager.GetButtonDown("Dash"))
                {
                    is_dashing = true;
                    bariera.SetActive(true);
                    dash_time = start_dash_time;
                    source.PlayOneShot(DashSound, 1);
                }
            }
            else
            {
                if (dash_time <= 0)
                {
                    is_dashing = false;
                    dash_time = start_dash_time;
                    bariera.SetActive(false);
                    dash_timer = dash_cooldown;
                    DashIcon.fillAmount = dash_timer / dash_cooldown;
                }
                else
                {
                    obrot = skrypt.GetComponent<CharacterController2D>().m_FacingRight;
                    dash_time -= Time.deltaTime;
                    if (obrot)
                    {
                        Instantiate(dash_effect, transform.position, Quaternion.identity);
                        rb.velocity = Vector2.right * dash_speed;
                    }
                    else
                    {
                        Instantiate(dash_effect, transform.position, Quaternion.identity);
                        rb.velocity = Vector2.left * dash_speed;
                    }
                }
            }

        }
        else
        {
            dash_timer -= Time.deltaTime;
            DashIcon.fillAmount = dash_timer / dash_cooldown;
        }

        animator.SetBool("ataklol", Mele_attacking);
        animator.SetBool("dashlol", is_dashing);
    }
}
