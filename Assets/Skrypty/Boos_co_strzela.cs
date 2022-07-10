using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boos_co_strzela : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float nearDistance;
    public bool lewo = true;
    public float MaxDistance;
    private SpriteRenderer obroc;
    [Header("References")]
    public GameObject projectile;
    private Transform target;
    private Transform szefuncio1;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        szefuncio1 = GameObject.FindGameObjectWithTag("sss").GetComponent<Transform>();
        obroc = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < nearDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > nearDistance)
        {
            transform.position = this.transform.position;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (szefuncio1.position.x < target.position.x)
        {
            lewo = false;
        }
        if (szefuncio1.position.x > target.position.x)
        {
            lewo = true;
        }

        if (lewo == true)
        {
            obroc.flipX = false;
        }
        if (lewo == false)
        {
            obroc.flipX = true;
        }
    }
}