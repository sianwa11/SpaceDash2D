using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public ParticleSystem explosion;
    public LevelLoader levelLoader;

    private PlayerController player;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth); // set maxHealth to 100

        player = GetComponent<PlayerController>(); // get a reference to the player controller
    }

    void Update()
    {
        // end game if health is 0
        if (currentHealth <= 0)
        {
            FindObjectOfType<GameManager>().TransitionToEnd();
        }
    }
    // Collission detection
    void OnCollisionEnter2D(Collision2D enemy)
    {
        if(enemy.gameObject.tag == "Enemy")
        {
            Debug.Log("HIT Enemy");
            // play death sound and reduce life
            takeDamage(20);

            // play particle system
            CreateExplosion();
        }
    }

    // trigger code
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cherry")
        {
            Destroy(other.gameObject);
            increaseLife(10);
        }

        if(other.gameObject.tag == "LevelComplete")
        {
            Debug.Log("Level Complete");
            player.enabled = false; // disable movement of player

            // animation to next scene
            levelLoader.LoadNextLevel();
        }
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

    void CreateExplosion()
    {
        explosion.Play();
    }

    void increaseLife(int life)
    {
        if (currentHealth < 100)
        {
            currentHealth += life;
            healthBar.setHealth(currentHealth);
        }
    }
}
