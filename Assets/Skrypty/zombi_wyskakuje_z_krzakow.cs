using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombi_wyskakuje_z_krzakow : MonoBehaviour
{
    public GameObject zombi_co_wyskakuje_z_krzaka;
    public float wyskok, skok;
    public AudioClip chlopcorobi;
    public int krzyk;
    private AudioSource source;

    private void Start()
    {
        krzyk = 0;
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (krzyk == 0)
            {
                source.PlayOneShot(chlopcorobi, 1);
                krzyk = 1;
                zombi_co_wyskakuje_z_krzaka.gameObject.SetActive(true);
                zombi_co_wyskakuje_z_krzaka.GetComponent<Rigidbody2D>().velocity = new Vector2(wyskok, skok);
            }
            else
            {

            }
        }
    }

}
