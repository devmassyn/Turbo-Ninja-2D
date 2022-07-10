using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class Kolizje : MonoBehaviour
{
    public AudioClip HitSound;
    public AudioClip SkrzyneczkaSound;
    public AudioClip ZwojSound;
    public AudioClip HeartsSound;
    public AudioClip LvlSound;
    public AudioClip CoinSound;
    private AudioSource source;
    private Animator anim;
    public GameObject cref;
    private bool czyZaliczony;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;    
    public Text monetytext;
    public Text zwojtext;
    public int buildIndex;
    public int zwoj, wynik,monety, health, numOfHearts;
    private int levelNumber;
    public PhysicsMaterial2D PlatformaCoSieKlei;
    private BoxCollider2D platformy;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();       
        
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        czyZaliczony = SaveSystem.GetBool("czyZaliczony" + (levelNumber - 1));
        if (czyZaliczony)
        {
            health = SaveSystem.GetInt("health" + (levelNumber - 1));
            zwoj = SaveSystem.GetInt("zwoj" + (levelNumber - 1));
            wynik = SaveSystem.GetInt("wynik" + (levelNumber - 1));
            numOfHearts= SaveSystem.GetInt("numOfHearts" + (levelNumber - 1));
            monety = SaveSystem.GetInt("monety" + (levelNumber - 1));
        }
        else
        {
            health = 3;
            zwoj = 0;
            wynik = 0;
            numOfHearts = 3;
            monety= 0;
        }
        PlatformaCoSieKlei.friction = 0;
        monetytext.text = "Monety: " + monety.ToString();
        zwojtext.text = "Zwoje: " + wynik.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        monetytext.text = "Monety: " + monety.ToString();
        zwojtext.text = "Zwoje: " + wynik.ToString();
        //health System
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            //Show max heart system with public var
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public void kupno (int kasa)
    {
        monety -= kasa;
        monetytext.text = "Monety: " + monety.ToString();
    }

    private void smierc(int obr)
    {
        if (obr <= 0)
        {
            SceneManager.LoadScene("GameOverScreen");
        }
        else
        {
            source.PlayOneShot(HitSound, 1);
            anim.Play("Efekt_Padaczki_Ale_Tylko_Troche", 0,0);
        }
    }
    public void Obrazenia(int ilosc)
    {
        health -= ilosc;
        Instantiate(cref, transform.position, Quaternion.identity);
        smierc(health);
    }
    public void Zwoje()
    {
        wynik++;
        zwoj++;
        source.PlayOneShot(ZwojSound, 1);
        zwojtext.text = "Zwoje: " + wynik.ToString();
        if (zwoj == 3)
        {
            zwoj = 0;
            if (numOfHearts >= hearts.Length)
            {

            }
            else if (numOfHearts < hearts.Length)
            {
                numOfHearts++;
            }
        }
    }
    public void Coiny()
    {
        monety++;
        source.PlayOneShot(CoinSound, 1);
        monetytext.text = "Monety: " + monety.ToString();
    }
    public void Serca()
    {
        source.PlayOneShot(HeartsSound, 1);


        health++;

    }
    public void Skrzyneczki()
    {
        source.PlayOneShot(SkrzyneczkaSound, 1);
    }
    public void Zagraj(AudioClip dzwiek)
    {
        source.PlayOneShot(dzwiek, 0.125f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Platforma"))
        {
            platformy = other.GetComponent<BoxCollider2D>();
            PlatformaCoSieKlei.friction = 1000;
            platformy.enabled = false;            
            platformy.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platforma"))
        {
            platformy = other.GetComponent<BoxCollider2D>();
            PlatformaCoSieKlei.friction = 0;
            platformy.enabled = false;
            platformy.enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag=="pisior")
        {
            this.transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "pisior")
        {
            transform.parent = null;
        }
    }
}
