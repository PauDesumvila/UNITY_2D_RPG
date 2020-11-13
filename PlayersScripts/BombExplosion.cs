using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public int damageToGive;
    public float timer;

    // damage blood burst animation
    public GameObject enemyDamageBurst;
    public Transform hitPoint;

    // damage points animation
    public GameObject damageNumber;

    // soundFX
    public AudioSource explosionSound;


    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            explosionSound.Play();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);

            // damage blood burst animation
            Instantiate(enemyDamageBurst, hitPoint.position, hitPoint.rotation);

            // damage points animation
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));            
            clone.GetComponent<DamageNumbers>().damageNumber = damageToGive;  // damage numbers adjusted when leveling up
        }
    }
}
