using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bos_co_robi_obrotuwe : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float nearDistance;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public bool lewo = true;
    public float MaxDistance;
    private SpriteRenderer obroc;
    [Header("References")]
    public GameObject projectile;
    private Transform target;
    private Transform szefuncio;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        szefuncio = GameObject.FindGameObjectWithTag("boss").GetComponent<Transform>();
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

        if (szefuncio.position.x > target.position.x)
        {
            lewo = true;
        }
        if (szefuncio.position.x < target.position.x)
        {
            lewo = false;
        }


        if (lewo == true)
        {
            obroc.flipX = true;
        }
        if (lewo == false)
        {
            obroc.flipX = false;
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}