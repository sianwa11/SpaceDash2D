using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1,10)]
    public float jumpVelocity;
    public KeyCode jumpKey;
    public bool grounded;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // to prevent double jumps
        if (collision.gameObject.tag == "Foreground")
        {
            grounded = true;
        }
    }

    void Update()
    {
        // later on fix this forward movement
        rb.velocity = new Vector2(7, rb.velocity.y);

        if (Input.GetKeyDown(jumpKey) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            grounded = false;
        }
    }
}
