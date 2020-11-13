using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioSource potionSound;
    public AudioSource doorSound;

    private static bool sfxManagerExist;
    
    void Start()
    {
        if (!sfxManagerExist)
        {
            sfxManagerExist = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
