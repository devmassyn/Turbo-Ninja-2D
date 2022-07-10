using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wylaczanie : MonoBehaviour
{
    public GameObject co_ma_zniknac;
    public GameObject co_ma_pojawic;
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                co_ma_zniknac.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            co_ma_pojawic.gameObject.SetActive(true);
        }
    }
}
