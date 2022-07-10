using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
public class Sklep : MonoBehaviour
{
    public GameObject gracz;
    public Kolizje zKolizje;
    public Canvas MENU_SKLEP_NA_POZIOMIE;
    public bool Kupuje;
    public bool czysklep;
    private int kasa;
    private AudioSource source;
    public AudioClip Poka_Bydlaka_Towara;
    public AudioClip Elo_Mordeczko;
    public int lastlevel;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        MENU_SKLEP_NA_POZIOMIE.enabled = false;
        lastlevel = SceneManager.GetActiveScene().buildIndex;
        SaveSystem.SetInt("lastlevel", lastlevel);
    }

    // Update is called once per frame
    void Update()
    {
        kasa = gracz.GetComponent<Kolizje>().monety;
        
        if ((CrossPlatformInputManager.GetButtonDown("Sklep"))&&(czysklep==true)&&(Kupuje==false))
            {
                Kupuje = true;
            }
        else if ((CrossPlatformInputManager.GetButtonDown("Sklep")) && (czysklep == true) && (Kupuje == true))
        {
            Kupuje = false;
        }
        if ((Kupuje == true)&& (czysklep==true))
        {
            gracz.GetComponent<PlayerMovement>().enabled = false;
            Time.timeScale = 0f;
            MENU_SKLEP_NA_POZIOMIE.enabled = true;
            
        } else if ((Kupuje == false)&&czysklep==true)
        {
            MENU_SKLEP_NA_POZIOMIE.enabled = false;
            Time.timeScale = 1f;
            gracz.GetComponent<PlayerMovement>().enabled = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           czysklep = true;

            source.PlayOneShot(Poka_Bydlaka_Towara, 1);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            czysklep = false;

            source.PlayOneShot(Elo_Mordeczko, 1);
        }
    }
    public void KupnoSerca()
    {
        if (gracz.GetComponent<Kolizje>().monety >= 10 && gracz.GetComponent<Kolizje>().health < gracz.GetComponent<Kolizje>().numOfHearts)
        {
            zKolizje.kupno(10);
            gracz.GetComponentInChildren<Kolizje>().health += 1;
        }
    }
    public void KupnoShuriken()
    {
        if (gracz.GetComponent<Kolizje>().monety >= 20 && gracz.GetComponent<PlayerAttack>().ile_shurikenow <10)
        {
            zKolizje.kupno(20);
            gracz.GetComponentInChildren<PlayerAttack>().ile_shurikenow += 5;
        }
    }
}
