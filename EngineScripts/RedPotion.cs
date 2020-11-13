using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotion : MonoBehaviour
{

    public LegionHealthManager legionHealth; 
    
    private SFXController sfxController;
    
    void Start()
    {
        legionHealth = FindObjectOfType<LegionHealthManager>();
        sfxController = FindObjectOfType<SFXController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Legion" )
        {
            sfxController.potionSound.Play();
            legionHealth.legionCurrentHealth = legionHealth.legionMaxHealth;            
            Destroy(gameObject);
        }
    }
}
