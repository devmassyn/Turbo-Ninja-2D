using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMusic : MonoBehaviour
{
    public AudioSource _as;

    void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            _as.mute = !_as.mute;
        }
    }
}
