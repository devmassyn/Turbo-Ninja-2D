using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ladowanie : MonoBehaviour
{
    public Image pasek;
    public float czasLadowania;
    private float ladowanieTimer;
    private int ktory_level;
    public GameObject loadingScreen;
    private bool klik;
    private void Start()
    {
        ladowanieTimer = 0;
        klik = false;
    }
    void Update()
    {
        if (klik)
        {
            if (ladowanieTimer < czasLadowania)
            {
                ladowanieTimer += Time.deltaTime;
                pasek.fillAmount = ladowanieTimer / czasLadowania;
            }
            else
            {
                pasek.fillAmount = ladowanieTimer / czasLadowania;
                SceneManager.LoadScene(ktory_level);
            }
        }
    }
    public void zaladuj (int level)
    {
        ktory_level = level;
        loadingScreen.SetActive(true);
        klik = true;
    }
}
