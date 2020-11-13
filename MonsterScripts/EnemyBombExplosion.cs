using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombExplosion : MonoBehaviour
{
    public int damageToGive;
    public float timer;

    // avoid damage when player rushing
    private LegionController legionController;

    void Start()
    {
        // avoid damage when player rushing
        legionController = FindObjectOfType<LegionController>();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Legion" && legionController.attackingRush == false)
        {            
            other.gameObject.GetComponent<LegionHealthManager>().HurtPlayer(damageToGive);    // adjust damage taken when leveling up
        }
    }
}
