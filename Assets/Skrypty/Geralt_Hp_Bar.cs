using UnityEngine;
using UnityEngine.UI;

public class Geralt_Hp_Bar : MonoBehaviour
{
    private float health, maxhealth;
    public Image HpBar;
    private Animator anim;
    private bool umar=false;
    public GameObject Sciana;
    public GameObject Wyjscie;
    public GameObject pasek;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Wyjscie.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        health = gameObject.GetComponent<EnemyObrazenia>().health;
        maxhealth = gameObject.GetComponent<EnemyObrazenia>().maxhealth;
        HpBar.fillAmount = health / maxhealth;
        if(health<=0&&!umar)
        {
            umar = true;
            anim.SetTrigger("smierc");
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.GetComponent<Geralt_AI>().enabled = false;
            pasek.SetActive(false);
            Sciana.SetActive(false);
            Wyjscie.SetActive(true);
        }
    }
}
