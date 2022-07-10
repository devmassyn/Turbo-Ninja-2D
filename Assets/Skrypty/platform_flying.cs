using UnityEngine;

public class platform_flying : MonoBehaviour
{
    public float predkosc_przesuwania;
    private Rigidbody2D flyingplatform;
    public Transform Punkt1;
    public Transform Punkt2;
    public bool flyleft;
    // Start is called before the first frame update
    void Start()
    {
        flyingplatform = gameObject.GetComponent<Rigidbody2D>();
        flyleft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (flyingplatform.transform.position.x < Punkt1.transform.position.x)
        {
            flyleft = false;
        }
        if (flyingplatform.transform.position.x > Punkt2.transform.position.x)
        {
            flyleft = true;
        }
        if (flyleft == true)
        {
            flyingplatform.velocity = new Vector2(-predkosc_przesuwania, flyingplatform.velocity.y);
        }
        if (flyleft == false)
        {
            flyingplatform.velocity = new Vector2(predkosc_przesuwania, flyingplatform.velocity.y);
        }

    }
}
