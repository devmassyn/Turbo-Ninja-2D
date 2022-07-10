using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow_cheat : MonoBehaviour
{
    private string[] slow;
    private int index;

    void Start()
    {
        slow = new string[] { "i", "m", "s", "n", "a", "i", "l" };
        index = 0;
    }

    void Update()
    {


        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(slow[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
        if (index == slow.Length)
        {
            Time.timeScale = 0.5f;
            index = 0;
        }

        

    }
}
