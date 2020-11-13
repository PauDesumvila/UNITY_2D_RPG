using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayerTrigger : MonoBehaviour
{

    public int damageToGive;

    // adjust damage taken when leveling up
    private LegionStats theLS;
    private int currentDamage;

    // avoid damage when player rushing
    private LegionController legionController;


    void Start()
    {
        // adjust damage taken when leveling up
        theLS = FindObjectOfType<LegionStats>();

        // avoid damage when player rushing
        legionController = FindObjectOfType<LegionController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Legion" && legionController.attackingRush == false)
        {
            // adjust damage taken when leveling up
            currentDamage = damageToGive - theLS.currentDefense;
            if (currentDamage <= 0)
            {
                currentDamage = 1;
            }

            //other.gameObject.GetComponent<LegionHealthManager>().HurtPlayer(damageToGive);
            other.gameObject.GetComponent<LegionHealthManager>().HurtPlayer(currentDamage);    // adjust damage taken when leveling up
        }
    }

}
