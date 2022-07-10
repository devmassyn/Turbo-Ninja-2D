using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    private bool[] level;
    private int ostatnipoziom;
    private void Start()
    {
        ostatnipoziom = SaveSystem.GetInt("lastlevel");
        level = new bool[SceneManager.sceneCountInBuildSettings];
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            level[i] = SaveSystem.GetBool("czyZaliczony" + i);
        }
    }
    public void LvlSelect(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void PlanszaMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlanszaAllLvl()
    {
        SceneManager.LoadScene("LvlSelect");
    }
    public void Kontynuuj()
    {
        SceneManager.LoadScene(ostatnipoziom);
    }
}