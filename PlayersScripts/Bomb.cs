using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float timer;
    public GameObject bombExplosion;
    private Rigidbody2D myRigidbody;
    private SpriteRenderer bombSprite;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        bombSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            
            if(timer < 1 && timer > 0.75) bombSprite.material.color = new Color(bombSprite.color.r, bombSprite.color.g, bombSprite.color.b);
            if (timer < 0.75 && timer > 0.5) bombSprite.material.color = new Color(0.925f, 0.231f, 0.231f);
            if (timer < 0.5 && timer > 0.25) bombSprite.material.color = new Color(bombSprite.color.r, bombSprite.color.g, bombSprite.color.b);
            if (timer < 0.25) bombSprite.material.color = new Color(0.925f, 0.231f, 0.231f);
        }
        if (timer <= 0)
        {           
            Instantiate(bombExplosion, new Vector3(myRigidbody.position.x, myRigidbody.position.y, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
