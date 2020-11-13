using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAppearing : MonoBehaviour
{
    public float timer;
    public GameObject ghost;
    private Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            Instantiate(ghost, new Vector3(myRigidbody.position.x, myRigidbody.position.y, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
