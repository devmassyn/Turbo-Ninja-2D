using UnityEngine;
using System.Collections;
public class Geralt_AI : MonoBehaviour
{
    private int rand;
    private Animator anim;
    private Transform Gracz;
    private bool m_FacingRight = false;
    private bool lewo;
    private SpriteRenderer obroc;
    public float distance;
    public float maxDistance;
    public float MoveSpeed = 3f;
    public float ActionCooldown;
    private float timer;
    private Vector2[] idle, wiel_up, kolejny, aktualna;
    public PolygonCollider2D polygonCollider2d;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        obroc = GetComponent<SpriteRenderer>();
        Gracz = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        idle = new Vector2[4];
        wiel_up = new Vector2[7];
        kolejny = new Vector2[4];
        przypisz();
    }

    // Update is called once per frame
    void Update()
    {
        Obrot();
        distance = Vector3.Distance(transform.position, Gracz.position);
        if (timer <= 0)
        {
            if (distance > maxDistance)
            {
                anim.SetBool("bieganie", true);
                polygonCollider2d.enabled = false;
                Flip();
                transform.position = Vector3.MoveTowards(transform.position, Gracz.position, Time.deltaTime * MoveSpeed);
            }
            else
            {
                anim.SetBool("bieganie", false);
                timer = ActionCooldown;
                rand = UnityEngine.Random.Range(0, 3);
                if (rand == 0)
                {
                    anim.SetTrigger("attackup");
                    Flip();
                    aktualna = wiel_up;
                    StartCoroutine("Zmien", 0.6f);
                }
                if (rand == 1)
                {
                    anim.SetTrigger("kolejnyattack");
                    Flip();
                    aktualna = kolejny;
                    StartCoroutine("Zmien", 0.6f);
                }
                if (rand == 2)
                {
                    anim.SetTrigger("wielgachny");
                    Flip();
                    aktualna = wiel_up;
                    StartCoroutine("Zmien", 0.6f);
                }
                StartCoroutine("Reset", 1f);
            }
        }
        else
        {
            anim.SetTrigger("idle");
            Flip();
            timer -= Time.deltaTime;
        }
    }
    private void Obrot()
    {
        if (transform.position.x >= Gracz.position.x)
        {
            lewo = true;
        }
        else if (transform.position.x < Gracz.position.x)
        {
            lewo = false;
        }
    }
    private void przypisz()
    {
        idle[0] = new Vector2(-0.04169922f, 0.1514419f);
        idle[1] = new Vector2(-0.01178436f, 0.1714082f);
        idle[2] = new Vector2(-0.0417099f, 0.4367612f);
        idle[3] = new Vector2(-0.07317811f, 0.4401003f);


        wiel_up[0] = new Vector2(0.4f, -0.3f);
        wiel_up[1] = new Vector2(0.5f, -0.1f);
        wiel_up[2] = new Vector2(0.4f, 0.1f);
        wiel_up[3] = new Vector2(0.3f, 0.3f);
        wiel_up[4] = new Vector2(0.0f, 0.4f);
        wiel_up[5] = new Vector2(0.1f, -0.1f);
        wiel_up[6] = new Vector2(0.2f, -0.3f);

        kolejny[0] = new Vector2(0.0f, -0.1f);
        kolejny[1] = new Vector2(0.1f, -0.2f);
        kolejny[2] = new Vector2(0.4f, -0.2f);
        kolejny[3] = new Vector2(0.4f, 0.0f);
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        if (lewo != m_FacingRight)
        {
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    IEnumerator Reset(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.        
        polygonCollider2d.enabled = false;
        polygonCollider2d.SetPath(0, idle);
        polygonCollider2d.enabled = true;
        yield return null;
    }
    IEnumerator Zmien(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.        
        polygonCollider2d.enabled = false;
        polygonCollider2d.SetPath(0, aktualna);
        polygonCollider2d.enabled = true;
        yield return null;

    }
}
