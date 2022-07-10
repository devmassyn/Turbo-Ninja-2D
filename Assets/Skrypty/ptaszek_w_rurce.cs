using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ptaszek_w_rurce : MonoBehaviour
{
    public GameObject wylacz_tlo, wylacz_muzyke, wylacz_niebo, napis;
    public GameObject wlacz_tlo, wlacz_muzyke, sciana;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("ptak"))
        {
            wylacz_tlo.gameObject.SetActive(false);
            wylacz_muzyke.gameObject.SetActive(false);
            wylacz_niebo.gameObject.SetActive(false);
            napis.gameObject.SetActive(false);

            sciana.gameObject.SetActive(false);
            wlacz_muzyke.gameObject.SetActive(true);
            wlacz_tlo.gameObject.SetActive(true);
        }
    }
}
