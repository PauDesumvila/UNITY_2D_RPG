using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai1Controller : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D myRigidBody;
    public bool isWalking;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;
    private int walkDirection;
    public Animator anim;
    public Vector2 lastMove;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }

    void Update()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    if (walkCounter > walkTime / 2)
                    {
                        myRigidBody.velocity = new Vector3(0, moveSpeed, 0);
                        anim.SetFloat("MoveX", myRigidBody.velocity.x);
                        anim.SetFloat("MoveY", myRigidBody.velocity.y);
                        anim.SetBool("Samurai1Moving", isWalking);
                        lastMove = new Vector2(myRigidBody.velocity.x, myRigidBody.velocity.y);
                    }
                    if (walkCounter < walkTime / 2)
                    {
                        myRigidBody.velocity = new Vector3(0, -moveSpeed, 0);
                        anim.SetFloat("MoveX", myRigidBody.velocity.x);
                        anim.SetFloat("MoveY", myRigidBody.velocity.y);
                        anim.SetBool("Samurai1Moving", isWalking);
                        lastMove = new Vector2(myRigidBody.velocity.x, myRigidBody.velocity.y);
                    }
                    break;
                case 1:
                    if (walkCounter > walkTime / 2)
                    {
                        myRigidBody.velocity = new Vector3(moveSpeed, 0, 0);
                        anim.SetFloat("MoveX", myRigidBody.velocity.x);
                        anim.SetFloat("MoveY", myRigidBody.velocity.y);
                        anim.SetBool("Samurai1Moving", isWalking);
                        lastMove = new Vector2(myRigidBody.velocity.x, myRigidBody.velocity.y);
                    }
                    if (walkCounter < walkTime / 2)
                    {
                        myRigidBody.velocity = new Vector3(-moveSpeed, 0, 0);
                        anim.SetFloat("MoveX", myRigidBody.velocity.x);
                        anim.SetFloat("MoveY", myRigidBody.velocity.y);
                        anim.SetBool("Samurai1Moving", isWalking);
                        lastMove = new Vector2(myRigidBody.velocity.x, myRigidBody.velocity.y);
                    }
                    break;
                case 2:
                    if (walkCounter > walkTime / 2)
                    {
                        myRigidBody.velocity = new Vector3(0, -moveSpeed, 0);
                        anim.SetFloat("MoveX", myRigidBody.velocity.x);
                        anim.SetFloat("MoveY", myRigidBody.velocity.y);
                        anim.SetBool("Samurai1Moving", isWalking);
                        lastMove = new Vector2(myRigidBody.velocity.x, myRigidBody.velocity.y);
                    }
                    if (walkCounter < walkTime / 2)
                    {
                        myRigidBody.velocity = new Vector3(0, moveSpeed, 0);
                        anim.SetFloat("MoveX", myRigidBody.velocity.x);
                        anim.SetFloat("MoveY", myRigidBody.velocity.y);
                        anim.SetBool("Samurai1Moving", isWalking);
                        lastMove = new Vector2(myRigidBody.velocity.x, myRigidBody.velocity.y);
                    }
                    break;
                case 3:
                    if (walkCounter > walkTime / 2)
                    {
                        myRigidBody.velocity = new Vector3(-moveSpeed, 0, 0);
                        anim.SetFloat("MoveX", myRigidBody.velocity.x);
                        anim.SetFloat("MoveY", myRigidBody.velocity.y);
                        anim.SetBool("Samurai1Moving", isWalking);
                        lastMove = new Vector2(myRigidBody.velocity.x, myRigidBody.velocity.y);
                    }
                    if (walkCounter < walkTime / 2)
                    {
                        myRigidBody.velocity = new Vector3(moveSpeed, 0, 0);
                        anim.SetFloat("MoveX", myRigidBody.velocity.x);
                        anim.SetFloat("MoveY", myRigidBody.velocity.y);
                        anim.SetBool("Samurai1Moving", isWalking);
                        lastMove = new Vector2(myRigidBody.velocity.x, myRigidBody.velocity.y);
                    }
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
                anim.SetBool("Samurai1Moving", isWalking);
                anim.SetFloat("LastMoveX", lastMove.x);
                anim.SetFloat("LastMoveY", lastMove.y);
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;

            myRigidBody.velocity = Vector2.zero;

            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
