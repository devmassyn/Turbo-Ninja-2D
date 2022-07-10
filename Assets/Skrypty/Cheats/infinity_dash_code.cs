using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infinity_dash_code : MonoBehaviour
{
    private string[] dash;
    private int index;

    void Start()
    {
        dash = new string[] { "j", "e", "t", "s", "k", "i" };
        index = 0;
    }

    void Update()
    {

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(dash[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
        if (index == dash.Length)
        {
            gameObject.GetComponent<PlayerAttack>().dash_cooldown = 0f;
            Debug.Log("cnb");
            index = 0;
        }

    }
}
