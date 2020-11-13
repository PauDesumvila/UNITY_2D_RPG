using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegionController : MonoBehaviour
{
    // movement
    public float moveSpeed;
    public Animator anim;
    private Rigidbody2D myRigidbody;
    private bool moving;
    public Vector2 lastMove;

    // basic attack
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    // rush attack
    public bool attackingRush;
    public float attackTimeRush;
    private float attackTimeCounterRush;

    // glow when rush attack
    public GameObject glow;

    // spark when rush attack
    public ParticleSystem spark;

    // bomb attack
    public Bomb bomb;

    // use magic points from healthmanager
    private LegionHealthManager legionHealth;

    // change areas, appear where we want, avoid duplicates
    private static bool legionExists;
    public string startPoint;

    // avoid movement when dialogue or message
    public bool canMove;

    // soundFX
    public AudioSource attackSound1;
    public AudioSource attackSound2;
    public AudioSource attackSound3;
    private int attackSoundCounter = 0;
    public AudioSource rushAttackSound;   
   

    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        // use magic points from healthmanager
        legionHealth = FindObjectOfType<LegionHealthManager>();

        // change areas, appear where we want, avoid duplicates
        if (!legionExists)
        {
            legionExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // allow movement after dialogue
        canMove = true;     
    }


    void Update()
    {
        moving = false;

        // set normal speed after rush attack
        if (!attackingRush) moveSpeed = 7;

        // glow when rush attack
        if (attackingRush) glow.SetActive(true);
        if (!attackingRush) glow.SetActive(false);

        // spark when rush attack
        if (attackingRush) spark.Play();
        if (!attackingRush) spark.Stop();

        // avoid movement when dialogue
        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            anim.SetBool("LegionMoving", false);
            return;            
        }

        // 8D movement
        if (Input.GetAxisRaw("Horizontal") > 0.0f || Input.GetAxisRaw("Horizontal") < 0.0f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
            moving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        if (Input.GetAxisRaw("Vertical") > 0.0f || Input.GetAxisRaw("Vertical") < 0.0f)
        {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            moving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        // stop movement when input stop
        if (Input.GetAxisRaw("Horizontal") == 0.0f)
        {
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") == 0.0f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }

        if (!attacking)
        {
            // basic attack
            if (Input.GetKeyDown(KeyCode.J))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidbody.velocity = Vector2.zero;               
                anim.SetBool("LegionAttacking", true);

                // sound attack changing
                attackSoundCounter++;
                if (attackSoundCounter == 1) attackSound1.Play();
                if (attackSoundCounter == 2) attackSound2.Play();
                if (attackSoundCounter == 3)
                {
                    attackSound2.Play();
                    attackSoundCounter = 0;
                }
                
            }

            // rush attack
            if (!attackingRush && legionHealth.legionCurrentMagic >= 20)
            {                
                if (Input.GetKeyDown(KeyCode.K))
                {
                    attackTimeCounterRush = attackTimeRush;
                    attackingRush = true;
                    moveSpeed = 18;
                    legionHealth.legionCurrentMagic -= 20;
                    rushAttackSound.Play();
                }
            }

            // bomb attack
            if (!attackingRush && legionHealth.legionCurrentMagic >= 50)
            {
                if (Input.GetKeyDown(KeyCode.L))
                {
                    Bomb clone = Instantiate(bomb, new Vector3(myRigidbody.position.x, myRigidbody.position.y, 0), Quaternion.identity);
                    legionHealth.legionCurrentMagic -= 50;
                }
            }
        }

        // stoping basic attack
        if(attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }
        if(attackTimeCounter <= 0)
        {
            attacking = false;            
            anim.SetBool("LegionAttacking", false);
        }
         
        // stoping rush attack
        if (attackTimeCounterRush > 0)
        {
            attackTimeCounterRush -= Time.deltaTime;
        }
        if (attackTimeCounterRush <= 0)
        {
            attackingRush = false;            
        }

        // movement animations
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("LegionMoving", moving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

    }
}
