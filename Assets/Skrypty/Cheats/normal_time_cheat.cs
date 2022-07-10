using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normal_time_cheat : MonoBehaviour
{
    private string[] normal;
    private int index;

    void Start()
    {
        // Code is "idkfa", user needs to input this in the right order

        normal = new string[] { "h", "u", "m", "a", "n", "t", "i", "m", "e" };
        index = 0;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(normal[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
        if (index == normal.Length)
        {
            Time.timeScale = 1.0f;
            index = 0;
        }

    }
}
