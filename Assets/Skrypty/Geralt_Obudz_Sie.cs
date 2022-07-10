using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geralt_Obudz_Sie : MonoBehaviour
{
    public GameObject Boss_bar;
    private GameObject Geralt;
    private AudioSource source;
    private bool wylaczona = true;
    private void Start()
    { 
        Geralt=GameObject.FindGameObjectWithTag("Geralt");
        Geralt.gameObject.GetComponent<Geralt_AI>().enabled = false;
        Geralt.gameObject.GetComponent<Grozny_Geralt>().enabled = false;
        Boss_bar.SetActive(false);
        source = Geralt.gameObject.GetComponent<AudioSource>();
        source.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&& wylaczona)
        {
            Geralt.gameObject.GetComponent<Geralt_AI>().enabled = true;
            wylaczona = false;
            Boss_bar.SetActive(true);
            Geralt.gameObject.GetComponent<Grozny_Geralt>().enabled = true;
            source.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
