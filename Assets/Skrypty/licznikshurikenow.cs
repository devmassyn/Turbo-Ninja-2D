using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class licznikshurikenow : MonoBehaviour
{
    public int shurikenow;
    public PlayerAttack Player_Attack;
    public Image[] shurikeny;
    public Sprite shuriken_jest, shurikena_nie_ma;
    void Update()
    {
        //health System
        shurikenow = Player_Attack.GetComponent<PlayerAttack>().ile_shurikenow;
        if (shurikenow >= 10)
        {
            shurikenow = 10;
            Player_Attack.GetComponent<PlayerAttack>().ile_shurikenow=10;
        }
        for (int i = 0; i < shurikeny.Length; i++)
        {
            if (i < shurikenow)
            {
                shurikeny[i].sprite = shuriken_jest;
            }
            else
            {
                shurikeny[i].sprite = shurikena_nie_ma;
            }
        }
    }
}
