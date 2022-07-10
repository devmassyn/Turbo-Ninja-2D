using UnityEngine;

public class Movement_flipped_right : MonoBehaviour
{
    public float predkosc;
    private Rigidbody2D wrog;
    public Transform lewyPunkt;
    public Transform prawyPunkt;
    public bool lewo;
    private SpriteRenderer obroc;
    // Start is called before the first frame update
    void Start()
    {
        obroc = GetComponent<SpriteRenderer>();
        wrog = GetComponent<Rigidbody2D>();
        lewo = false;
        SendMessageUpwards("cokolwiek", predkosc);
    }

    // Update is called once per frame
    void Update()
    {
        if (wrog.position.x < lewyPunkt.position.x)
        {
            lewo = true;
        }
        if (wrog.position.x > prawyPunkt.position.x)
        {
            lewo = false;
        }
        if (lewo == true)
        {
            obroc.flipX = false;
            wrog.velocity = new Vector2(predkosc, wrog.velocity.y);
        }
        if (lewo == false)
        {
            obroc.flipX = true;
            wrog.velocity = new Vector2(-predkosc, wrog.velocity.y);
        }

    }
}
