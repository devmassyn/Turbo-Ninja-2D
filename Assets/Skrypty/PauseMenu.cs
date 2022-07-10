using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zKolizje;
    public bool[] czyZaliczony;
    private int levelNumber;
    public static bool GameIsPaused = false;
    public Canvas MENUPAUZA;
    public GameObject SKLEP_OBJEKT;
    public GameObject gracz;


    void Start()
    {
        MENUPAUZA.enabled = false;
        SKLEP_OBJEKT.GetComponent<Sklep>().enabled = true;
        czyZaliczony = new bool[SceneManager.sceneCountInBuildSettings];
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        czyZaliczony[levelNumber - 1] = SaveSystem.GetBool("czyZaliczony" + (levelNumber - 1));
        czyZaliczony[0] = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (GameIsPaused)
            {
                SKLEP_OBJEKT.GetComponent<Sklep>().enabled = true;
                Resume();
            }
            else
            {
                SKLEP_OBJEKT.GetComponent<Sklep>().enabled = false;
                Pause();
            }
        }
    }
    public void Resume()
    {
        gracz.GetComponent<PlayerMovement>().enabled = true;
        gracz.GetComponent<PlayerAttack>().enabled = true;
        MENUPAUZA.enabled = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        gracz.GetComponent<PlayerMovement>().enabled = false;
        gracz.GetComponent<PlayerAttack>().enabled = false;
        MENUPAUZA.enabled = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SaveGame()
    {
        czyZaliczony[levelNumber] = true;
        SaveSystem.SetInt("zwoj" + levelNumber, zKolizje.GetComponent<Kolizje>().zwoj);
        SaveSystem.SetInt("monety" + levelNumber, zKolizje.GetComponent<Kolizje>().monety);
        SaveSystem.SetInt("wynik" + levelNumber, zKolizje.GetComponent<Kolizje>().wynik);
        SaveSystem.SetInt("health" + levelNumber, zKolizje.GetComponent<Kolizje>().health);
        SaveSystem.SetInt("numOfHearts" + levelNumber, zKolizje.GetComponent<Kolizje>().numOfHearts);
        SaveSystem.SetInt("ile_shurikenow" + levelNumber, zKolizje.GetComponent<PlayerAttack>().ile_shurikenow);
        SaveSystem.SetBool("czyZaliczony" + levelNumber, czyZaliczony[levelNumber]);
    }
}
