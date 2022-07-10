using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;

    void Start()
    {
        dialogBox.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            dialogBox.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogBox.SetActive(false);
        }
    }
       
}
