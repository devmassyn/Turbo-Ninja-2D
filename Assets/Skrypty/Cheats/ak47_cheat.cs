using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ak47_cheat : MonoBehaviour
{
    private string[] aka;
    private bool akacz;
    private int index;

    void Start()
    {
        akacz = false;
        aka = new string[] { "l", "i", "k", "e", "a", "r", "a", "m", "b", "o" };
        index = 0;
    }

    void Update()
    {

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(aka[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
        if (index == aka.Length)
        {
            if (akacz == false)
            {
                gameObject.GetComponent<PlayerAttack>().ak = true;
                index = 0;
                akacz = true;
            }
            else if (akacz == true)
            {
                gameObject.GetComponent<PlayerAttack>().ak = false;
                index = 0;
                akacz = false;
            }
            Debug.Log("cos");
        }

    }
}
