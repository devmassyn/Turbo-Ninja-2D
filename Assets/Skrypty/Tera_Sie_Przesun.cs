using UnityEngine;

public class Tera_Sie_Przesun : MonoBehaviour
{
    public Latajaca_Platforma_Ale_Taka_Fajna siePrzesun;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            siePrzesun.GetComponent<Latajaca_Platforma_Ale_Taka_Fajna>().MoveSpeed = 5;
        }
    }
}
