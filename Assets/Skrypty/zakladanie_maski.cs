using UnityEngine;

public class zakladanie_maski : MonoBehaviour
{
    private Animator animator;

    public void Za (bool swim)
    {
        gameObject.GetComponent<Animator>().SetBool("swimming", swim);
    }
}
