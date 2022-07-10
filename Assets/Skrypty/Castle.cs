using UnityEngine;
using UnityEngine.SceneManagement;
public class Castle : MonoBehaviour
{
    public GameObject zKolizje;
    public bool[] czyZaliczony;
    private int levelNumber;
    private void Start()
    {
        czyZaliczony = new bool[SceneManager.sceneCountInBuildSettings];        
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        czyZaliczony[levelNumber - 1] = SaveSystem.GetBool("czyZaliczony" + (levelNumber - 1));
        czyZaliczony[0] = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            czyZaliczony[levelNumber] = true;
            SaveSystem.SetInt("zwoj" + levelNumber, zKolizje.GetComponent<Kolizje>().zwoj);
            SaveSystem.SetInt("monety" + levelNumber, zKolizje.GetComponent<Kolizje>().monety);
            SaveSystem.SetInt("wynik" + levelNumber, zKolizje.GetComponent<Kolizje>().wynik);
            SaveSystem.SetInt("health" + levelNumber, zKolizje.GetComponent<Kolizje>().health);
            SaveSystem.SetInt("numOfHearts" + levelNumber, zKolizje.GetComponent<Kolizje>().numOfHearts);
            SaveSystem.SetInt("ile_shurikenow" + levelNumber, zKolizje.GetComponent<PlayerAttack>().ile_shurikenow);
            SaveSystem.SetBool("czyZaliczony" + levelNumber, czyZaliczony[levelNumber]);
            SceneManager.LoadScene(levelNumber+1);
        }
    }
}
