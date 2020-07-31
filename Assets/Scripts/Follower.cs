using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    private Transform pos;
    private Rigidbody2D rb;
    public float forwardMovement = 9f;
    public int stop;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        stop = (int)pos.position.x;
        rb.velocity = new Vector2(forwardMovement, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "RocketTrigger")
        {
            Debug.Log("Rokeet");
            forwardMovement = 16;
        }
        else if (other.gameObject.tag == "BallTrigger")
        {
            Debug.Log("Bwall");
            forwardMovement = 9;
        }
    }
}
