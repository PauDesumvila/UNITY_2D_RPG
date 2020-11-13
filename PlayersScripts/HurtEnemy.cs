using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    public int damageToGive;

    // adjust damage when leveling up
    private LegionStats theLS;
    private int currentDamage;


    // damage blood burst animation
    public GameObject enemyDamageBurst;
    public Transform hitPoint;

    // damage points animation
    public GameObject damageNumber;
	
	void Start () {
        // adjust damage when leveling up
        theLS = FindObjectOfType<LegionStats>();
    }

    void Update () {       
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            var randomCritical = Random.Range(-2, 3);  // add random variations in damage for critical strikes

            // adjust damage when leveling up
            currentDamage = damageToGive + theLS.currentAttack;


            //Destroy(other.gameObject);                                                                         // kill enemy in one attack
            //other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive + randomCritical);      // hurt certain amount of damage
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage + randomCritical);       // hurt certain amount of damage adjusted when leveling up

            // damage blood burst animation
            Instantiate(enemyDamageBurst, hitPoint.position, hitPoint.rotation);

            // damage points animation
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            //clone.GetComponent<DamageNumbers>().damageNumber = damageToGive + randomCritical;
            clone.GetComponent<DamageNumbers>().damageNumber = currentDamage + randomCritical;  // damage numbers adjusted when leveling up
        }
    }
}
