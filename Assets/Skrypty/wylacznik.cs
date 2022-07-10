using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wylacznik : MonoBehaviour
{
    [Header ("Wylaczanie")]
    public GameObject[] wylacz;
    [Header ("Wlaczanie")]
    public GameObject[] wlacz;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            wylacz[0].gameObject.SetActive(false);
            wylacz[1].gameObject.SetActive(false);
            wylacz[2].gameObject.SetActive(false);
            wylacz[3].gameObject.SetActive(false);
            wylacz[4].gameObject.SetActive(false);
            wylacz[5].gameObject.SetActive(false);
            wylacz[6].gameObject.SetActive(false);
            wylacz[7].gameObject.SetActive(false);
            wylacz[8].gameObject.SetActive(false);
            wylacz[9].gameObject.SetActive(false);
            wylacz[10].gameObject.SetActive(false);
            wylacz[11].gameObject.SetActive(false);
            wylacz[12].gameObject.SetActive(false);
            wylacz[13].gameObject.SetActive(false);
            wylacz[14].gameObject.SetActive(false);

            wlacz[0].gameObject.SetActive(true);
            wlacz[1].gameObject.SetActive(true);
            wlacz[2].gameObject.SetActive(true);
            wlacz[3].gameObject.SetActive(true);
            wlacz[4].gameObject.SetActive(true);
            wlacz[5].gameObject.SetActive(true);
            wlacz[6].gameObject.SetActive(true);
            wlacz[7].gameObject.SetActive(true);
            wlacz[8].gameObject.SetActive(true);
            wlacz[9].gameObject.SetActive(true);
            wlacz[10].gameObject.SetActive(true);
            wlacz[11].gameObject.SetActive(true);
            wlacz[12].gameObject.SetActive(true);
        }
    }
}
