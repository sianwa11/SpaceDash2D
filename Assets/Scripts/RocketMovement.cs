using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private TrailRenderer trail;

    public float upForce = 200f;
    public float forwardForce = 7f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
    }
   

    void Update()
    {
        rb.velocity = new Vector2(forwardForce, rb.velocity.y);
        rb.freezeRotation = true; // freeze rotation of rocket on z axis

        trail.enabled = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, upForce));
        }
    }

}

/*
    Rigidbody2D rb;

    public float speed;
    public float accelaration;
    public float rotationControl;
    float MovX, MovY = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovY = Input.GetAxis("Vertical");
        rb.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    void FixedUpdate()
    {
        Vector2 vel = transform.right * (MovX * accelaration);
        rb.AddForce(vel);

        float dir = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));

        if(accelaration > 0)
        {
            if (dir > 0)
            {
                rb.rotation += MovY * rotationControl * (rb.velocity.magnitude / speed);
            }
            else
            {
                rb.rotation -= MovY * rotationControl * (rb.velocity.magnitude / speed);
            }
        }

        float thrustForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * 2.0f;

        Vector2 relForce = Vector2.up * thrustForce;

        rb.AddForce(rb.GetRelativeVector(relForce));

        if(rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }*/

// flappy bird mwitu
/*    // Movement speed
    public float speed = 7f;

    // Flap force
    public float force = 300f;


    // Use this for initialization
    void Start()
    {
        // Fly towards the right
       // GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        // Flap
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
    }*/


// flappy bird
/* Vector3 velocity = Vector3.zero;
 public Vector3 gravity;
 public Vector3 flyVelocity;
 public Rigidbody2D rb;

 public float maxSpeed = 5f;
 public float forwardSpeed = 7f;

 bool didFly = false;
*/

// Start is called before the first frame update
/* void Start()
 {
    // rb = GetComponent<Rigidbody2D>();
    // rb.GetComponent<Rigidbody2D>().gravityScale = 0;
 }*/

// Update is called once per frame
/* void Update()
 {
     if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
     {
         didFly = true;
     }
 }

 // Physics engine update here
 void FixedUpdate()
 {
     velocity.x = forwardSpeed;
     velocity += gravity * Time.deltaTime;

     if (didFly)
     {
         didFly = false;
         if (velocity.y < 0)
             velocity.y = 0;
         velocity += flyVelocity;
     }

     velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

     transform.position += velocity * Time.deltaTime;

     float angle = 0;
     if(velocity.y < 0)
     {
         angle = Mathf.Lerp(0, -8, -velocity.y / angle);
     }
     transform.rotation = Quaternion.Euler(0, 0, angle);
 }*/
//}
