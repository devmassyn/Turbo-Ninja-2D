using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bars : MonoBehaviour
{
    public GameObject co_ma_zniknac;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("sss"))
        {
            co_ma_zniknac.gameObject.SetActive(true);
        }
    }
}
