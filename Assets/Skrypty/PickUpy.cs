
using UnityEngine;

public class PickUpy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player")) && (this.gameObject.CompareTag("Zwoj")))
        {
            other.SendMessageUpwards("Zwoje");
            this.gameObject.SetActive(false);
        }
        if ((other.gameObject.CompareTag("Player")) && (this.gameObject.CompareTag("coin")))
        {
            other.SendMessageUpwards("Coiny");
            this.gameObject.SetActive(false);
        }
        if ((other.gameObject.CompareTag("Player")) && (this.gameObject.CompareTag("serce")))
        {
            other.SendMessageUpwards("Serca");
            this.gameObject.SetActive(false);
        }
    }
}