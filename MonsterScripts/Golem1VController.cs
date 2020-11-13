using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem1VController : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D myRigidBody;
    public bool isWalking;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;
    public Animator anim;
    public Vector2 lastMove;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        isWalking = true;
    }

    void Update()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;

            if (walkCounter > walkTime / 2)
            {
                myRigidBody.velocity = new Vector3(0, moveSpeed, 0);
                anim.SetFloat("MoveX", myRigidBody.velocity.x);
                anim.SetFloat("MoveY", myRigidBody.velocity.y);
                anim.SetBool("Golem1Moving", isWalking);
                lastMove = new Vector2(myRigidBody.velocity.x, myRigidBody.velocity.y);
            }
            if (walkCounter < walkTime / 2)
            {
                myRigidBody.velocity = new Vector3(0, -moveSpeed, 0);
                anim.SetFloat("MoveX", myRigidBody.velocity.x);
                anim.SetFloat("MoveY", myRigidBody.velocity.y);
                anim.SetBool("Golem1Moving", isWalking);
                lastMove = new Vector2(myRigidBody.velocity.x, myRigidBody.velocity.y);
            }

            if (walkCounter < 0)
            {                
                waitCounter = waitTime;
                walkCounter = walkTime;
                anim.SetBool("Golem1Moving", isWalking);
                anim.SetFloat("LastMoveX", lastMove.x);
                anim.SetFloat("LastMoveY", lastMove.y);
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;
        }
    }
}
