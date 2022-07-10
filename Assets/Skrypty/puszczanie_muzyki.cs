using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puszczanie_muzyki : MonoBehaviour
{
    public GameObject audios;

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(true);
    }
}
