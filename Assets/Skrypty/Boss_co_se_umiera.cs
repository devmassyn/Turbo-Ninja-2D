using UnityEngine;
using System.Collections;

public class Boss_co_se_umiera : MonoBehaviour
{
    private int ile_hp;
    public GameObject dymy;
    public GameObject wybuchy;
    private float WaitTime=1f;
    private void Start()
    {
        gameObject.GetComponent<EnemyObrazenia>().czyMoznaUmrzec = false;
    }
    void Update()
    {
        ile_hp = gameObject.GetComponent<EnemyObrazenia>().health;
        if (ile_hp <=2)
        {
            Instantiate(dymy, transform.position, Quaternion.identity);
        }
        if (ile_hp <=0)
        {
            Instantiate(wybuchy, transform.position, Quaternion.identity);
            gameObject.GetComponent<bos_co_robi_obrotuwe>().enabled = false;
            StartCoroutine("Reset", WaitTime);
        }
    }
    IEnumerator Reset(float Count)
    {
        yield return new WaitForSeconds(Count);
        gameObject.GetComponent<EnemyObrazenia>().czyMoznaUmrzec = true;
        gameObject.GetComponent<EnemyObrazenia>().obrazenia(1);
        yield return null;
    }
}
