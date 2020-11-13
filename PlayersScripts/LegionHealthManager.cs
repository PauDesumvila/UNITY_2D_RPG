using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LegionHealthManager : MonoBehaviour {

    // health points
    public int legionMaxHealth;
    public int legionCurrentHealth;

    // magic points
    public int legionMaxMagic;
    public int legionCurrentMagic;

    // show damage to player(getting red)
    public bool damageFlashActive;
    public float damageFlashLength;
    private float damageFlashCounter;
    private SpriteRenderer legionSprite;

    // damage blood burst animation
    public GameObject playerDamageBurst;
    public Transform player;

    void Start () {
        // health points
        legionCurrentHealth = legionMaxHealth;

        // magic points
        legionCurrentMagic = legionMaxMagic;

        // show damage to player(getting red)
        legionSprite = GetComponent<SpriteRenderer>();

    }

    void Update () {

        // show damage to player(getting red)
        if (damageFlashActive)
        {
            if(damageFlashCounter > damageFlashLength * 0.66f)
            {
                legionSprite.material.color = new Color(0.925f, 0.231f, 0.231f);  // get red
            } else if(damageFlashCounter > damageFlashLength * 0.33f)
            {
                legionSprite.material.color = new Color(legionSprite.color.r, legionSprite.color.g, legionSprite.color.b); // get normal color
            } else if(damageFlashCounter > 0f)
            {
                legionSprite.material.color = new Color(0.925f, 0.231f, 0.231f);  // get red
            } else
            {
                legionSprite.material.color = new Color(legionSprite.color.r, legionSprite.color.g, legionSprite.color.b); // get normal color 
                damageFlashActive = false;
            }
            damageFlashCounter -= Time.deltaTime;
        }

        // start from startPoint when dying
        /*if (legionCurrentHealth <= 0)
        {
            gameObject.SetActive(false);                                       // destroy player
            SetMaxHealth();                                                    // set health again to max health
            SetMaxMagic();                                                     // set magic again to max magic 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);        // reload scene           
            gameObject.SetActive(true);                                        // put back again the player onto the scene     

        }*/
        // start from startPoint when dying
        if (legionCurrentHealth <= 0)
        {
            //gameObject.SetActive(false);                                       // destroy player
            //Destroy(gameObject);
        }
    }

    public void HurtPlayer(int damageToGive) 
    {
        legionCurrentHealth -= damageToGive;

        // show damage to player(getting red)
        damageFlashActive = true;
        damageFlashCounter = damageFlashLength;

        // damage blood burst animation
        Instantiate(playerDamageBurst, player.position, player.rotation);
    }

    // health points
    public void SetMaxHealth()
    {
        legionCurrentHealth = legionMaxHealth;
    }

    // magic points
    public void SetMaxMagic()
    {
        legionCurrentMagic = legionMaxMagic;
    }
}
