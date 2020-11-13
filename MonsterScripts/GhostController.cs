using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    private Transform player;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator anim;
    public Vector2 lastMove;
    public bool isWalking;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
        isWalking = true;
        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        anim.SetBool("GhostMoving", isWalking);
        lastMove = new Vector2(rb.velocity.x, rb.velocity.y);       
    }

    private void FixedUpdate()
    {
        moveGhost(movement);
    }

    void moveGhost(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
