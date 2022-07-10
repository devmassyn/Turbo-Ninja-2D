using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godmode : MonoBehaviour
{
    private string[] god;
    private int index;

    void Start()
    {
        // Code is "idkfa", user needs to input this in the right order
        god = new string[] { "l", "e", "g", "e","n","d","s","n","e","v","e","r","d","i","e" };
        index = 0;
    }

    void Update()
    {

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(god[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
        if (index == god.Length)
        {
            gameObject.GetComponent<Kolizje>().numOfHearts = 10000;
            gameObject.GetComponent<Kolizje>().health = 10000;
            index = 0;
        }

    }
}
