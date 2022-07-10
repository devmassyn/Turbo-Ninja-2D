using UnityEngine;

public class Niszczarka_Ninja : MonoBehaviour
{
    public GameObject rozpadanie;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")&&!other.gameObject.CompareTag("Throwable")&&!other.gameObject.CompareTag("coin")&&!other.gameObject.CompareTag("Zwoj"))
        {
            Destroy(this.gameObject);
            Instantiate(rozpadanie, transform.position, Quaternion.identity);
        }
    }
}
