using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostStartPoint : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    public GameObject ghostAppearing;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < 3)
        {
            Instantiate(ghostAppearing, new Vector3(rb.position.x, rb.position.y, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
