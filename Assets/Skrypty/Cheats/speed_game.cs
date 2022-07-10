using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed_game : MonoBehaviour
{
    private string[] speed;
    private int index;

    void Start()
    {
        // Code is "idkfa", user needs to input this in the right order
        speed = new string[] { "s", "p", "e", "e", "d", "m", "e", "u", "p" };
        index = 0;
    }

    void Update()
    {

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(speed[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
        if (index == speed.Length)
        {
            Time.timeScale = 5.0f;
            index = 0;
        }

    }
}
