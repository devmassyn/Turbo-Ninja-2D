using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moris_wywinduj_mnie : MonoBehaviour
{
    public float predkosc_wywindowania;
    private Rigidbody2D windownik;
    public Transform Punkt1;
    public Transform Punkt2;
    public bool windowanie;
    // Start is called before the first frame update
    void Start()
    {
        windownik = gameObject.GetComponent<Rigidbody2D>();
        windowanie = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (windownik.transform.position.y < Punkt1.transform.position.y)
        {
            windowanie = false;
        }
        if (windownik.transform.position.y > Punkt2.transform.position.y)
        {
            windowanie = true;
        }
        if (windowanie == true)
        {
            windownik.velocity = new Vector2(0, -predkosc_wywindowania);
        }
        if (windowanie == false)
        {
            windownik.velocity = new Vector2(0, predkosc_wywindowania);
        }

    }
}
