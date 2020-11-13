using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Dragon1Controller : MonoBehaviour
{
    private Transform player;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator anim;
    public Vector2 lastMove;
    public bool isWalking;
    public GameObject fireBall;
    private float shootCounter;
    public float shootTime;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < 5)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            movement = direction;
            isWalking = true;
            anim.SetFloat("MoveX", direction.x);
            anim.SetFloat("MoveY", direction.y);
            anim.SetBool("Dragon1Moving", isWalking);
            lastMove = new Vector2(rb.velocity.x, rb.velocity.y);

            shootCounter -= Time.deltaTime;
            if(shootCounter < 0)
            {
                GameObject clone = Instantiate(fireBall, new Vector3(rb.position.x, rb.position.y, 0), Quaternion.identity);
                shootCounter = shootTime;
            }
        }
        if (Vector2.Distance(transform.position, player.position) > 5)
        {
            movement = Vector2.zero;
            lastMove = new Vector2(rb.velocity.x, rb.velocity.y);
            shootCounter -= Time.deltaTime;
            if (shootCounter < 0)
            {
                GameObject clone = Instantiate(fireBall, new Vector3(rb.position.x, rb.position.y, 0), Quaternion.identity);
                shootCounter = shootTime;
            }
        }
    }

    private void FixedUpdate()
    {
        moveDragon1(movement);
    }

    void moveDragon1(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
