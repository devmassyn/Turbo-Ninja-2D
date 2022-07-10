using System.Collections;
using UnityEngine;

public class Skrzyneczka : MonoBehaviour
{

    public GameObject rozpadanie;
    public GameObject drop;
    private float WaitTime = 0.1f;
    public float vert;
    public float hor;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Reset", WaitTime);
            other.SendMessageUpwards("Skrzyneczki");
        }
    }
    IEnumerator Reset(float Count)
    {
        yield return new WaitForSeconds(Count); //Count is the amount of time in seconds that you want to wait.        
        Instantiate(rozpadanie, transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
        drop.gameObject.SetActive(true);
        drop.GetComponent<Rigidbody2D>().velocity = new Vector2(hor, vert);
        yield return null;
    }
}
