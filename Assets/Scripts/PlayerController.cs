using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1,10)]
    public float jumpVelocity;
    public float forwardMovement = 7f;
    public KeyCode jumpKey;
    public bool grounded;

    // reference variables
    public Rigidbody2D rb;
    public TrailRenderer trail;
    public ParticleSystem dust;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.GetComponent<RocketMovement>().enabled = false;
        trail = GetComponent<TrailRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // to prevent double jumps
        if (collision.gameObject.tag == "Foreground" || collision.gameObject.tag == "Enemy")
        {
            grounded = true;
            trail.enabled = false;
            createDust(); // play particle when player lands
        }
    }

    void Update()
    {
        // later on fix this forward movement
        rb.velocity = new Vector2(forwardMovement, rb.velocity.y);

        if (Input.GetKeyDown(jumpKey) && grounded)
        {
            trail.enabled = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            grounded = false;
        }

        // Game Over if player goes lower than platforms
        if(rb.position.y < 1)
        {
           // FindObjectOfType<GameManager>().TransitionToEnd();
        }
    }

    public void createDust()
    {
        dust.Play();
    }
}
