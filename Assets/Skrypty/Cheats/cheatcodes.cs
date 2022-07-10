using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheatcodes : MonoBehaviour
{
    private string[] wincyj_szurikenow;
    private int index;

    void Start()
    {
        // Code is "idkfa", user needs to input this in the right order
        wincyj_szurikenow = new string[] { "m", "o", "r","e","s", "h", "u", "r", "i", "k", "e", "n", "s" };
        index = 0;
    }

    void Update()
    {
        
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(wincyj_szurikenow[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
        if (index == wincyj_szurikenow.Length)
        {
            gameObject.GetComponent<PlayerAttack>().ile_shurikenow += 10;
            index = 0;
        }
    }
}
