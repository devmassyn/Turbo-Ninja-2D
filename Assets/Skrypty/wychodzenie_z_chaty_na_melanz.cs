using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wychodzenie_z_chaty_na_melanz : MonoBehaviour
{
    public GameObject ziomal_co_idzie_na_melo;
    public GameObject sciana;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ziomal_co_idzie_na_melo.gameObject.SetActive(true);
            sciana.gameObject.SetActive(true);
        }
    }
}
