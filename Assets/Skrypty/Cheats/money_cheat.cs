using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money_cheat : MonoBehaviour
{
    private string[]piniondz;
    private int index;
    void Start()
    {
        piniondz = new string[] { "a", "f", "e", "l", "t", "i", "n", "i", "o" };
        index = 0;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(piniondz[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
        if (index == piniondz.Length)
        {
            gameObject.GetComponent<Kolizje>().monety += 20;
            gameObject.GetComponent<Kolizje>().monetytext.text = "Monety: " + gameObject.GetComponent<Kolizje>().monety.ToString();
            index = 0;
        }
    }
}
