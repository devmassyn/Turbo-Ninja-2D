using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObrazenia : MonoBehaviour
{
    public int health,maxhealth;
    public int dmg;
    public AudioClip DzwiekObrazen;
    private Animator anim;
    public Kolizje gramy;
    public GameObject final;
    public GameObject cref;
    public bool czyMoznaUmrzec=true;
    public bool zniszcz = true;
    public bool jesliWypada = false;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        health *= 2;
        maxhealth = health;
        czyMoznaUmrzec = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Weapon")|| other.gameObject.CompareTag("Throwable"))
        {
            obrazenia(dmg);
            gramy.Zagraj(DzwiekObrazen);
        }
    }
    private void smierc(int obr)
    {
        if ((obr <= 0)&& czyMoznaUmrzec)
        {
            if (zniszcz == true)
            {
                Destroy(gameObject);
            }
            if (jesliWypada == true)
            {
                final.gameObject.SetActive(true);
            }
        }
    }
    public void obrazenia(int ilosc)
    {
        health -= ilosc;
        smierc(health);
        anim.Play("Efekt_Padaczki_Ale_Tylko_Troche");
        Instantiate(cref, transform.position, Quaternion.identity);
    }
}
