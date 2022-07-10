using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class high_jump_cheat : MonoBehaviour
{
    private string[] high;
    public bool ninja;
    private int index;

    void Start()
    {
        high = new string[] { "n","i","n","j","a","j","u","m","p" };
        index = 0;
    }

    void Update()
    {

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(high[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
        if (index == high.Length)
        {
            if (ninja == false)
            {
                index = 0;
                ninja = true;
            }
            else if(ninja == true)
            {
                index = 0;
                ninja = false;
            }
        }


    }
}
