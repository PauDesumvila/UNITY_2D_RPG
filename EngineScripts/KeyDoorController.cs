using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorController : MonoBehaviour
{
    public GameObject door;

    private SFXController sfxController;


    void Start()
    {        
        sfxController = FindObjectOfType<SFXController>();
    }

    private void OnDestroy()
    {        
        Destroy(door);
    }   


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Legion")
        {
            sfxController.doorSound.Play();
            Destroy(gameObject);
        }
    }
}
