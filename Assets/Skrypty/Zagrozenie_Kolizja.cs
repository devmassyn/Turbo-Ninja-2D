using UnityEngine;

public class Zagrozenie_Kolizja : MonoBehaviour
{
    public int ile_obrazen;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.SendMessageUpwards("Obrazenia", ile_obrazen);
        }
    }

}
