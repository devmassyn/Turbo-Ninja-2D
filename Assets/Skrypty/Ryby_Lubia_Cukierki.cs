using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Ryby_Lubia_Cukierki : MonoBehaviour
{
    private Animator anim;
    public GameObject cukierek;
    public Text Karp, Gyarados;
    private void Start()
    {
        anim = GetComponent<Animator>();
        Karp.enabled = true;
        Gyarados.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("sss")&&!other.GetComponent<Rare_Candy>().czyPodniesiony)
        {
            cukierek.gameObject.SetActive(false);
            anim.SetBool("duzy_wonsz", true);
            Karp.enabled = false;
            Gyarados.enabled = true;
        }
    }
}
