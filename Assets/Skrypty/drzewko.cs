using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drzewko : MonoBehaviour
{
    public Animator animator;
    public GameObject m1, m2, tlo, tlowyl, sciana, noc;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("wkurzone", true);
            m1.gameObject.SetActive(false);
            m2.gameObject.SetActive(true);
            tlo.gameObject.SetActive(true);
            tlowyl.gameObject.SetActive(false);
            sciana.gameObject.SetActive(true);
            noc.gameObject.SetActive(true);
        }
    }
    
}