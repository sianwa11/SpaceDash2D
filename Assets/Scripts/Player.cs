using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public ParticleSystem explosion;
    public LevelLoader levelLoader;

    private PlayerController player;
    private Transform pos;
    public int playerStopped;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth); // set maxHealth to 100

        player = GetComponent<PlayerController>(); // get a reference to the player controller
        pos = GetComponent<Transform>();
    }

    void Update()
    {
        playerStopped = (int)pos.position.x;
        // if the player is stuck restart the game
        if (FindObjectOfType<Follower>() != null)
        {
            if (FindObjectOfType<Follower>().stop == playerStopped)
            {
                Debug.Log("Same");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
        // end game if health is 0
        if (currentHealth <= 0)
        {
            FindObjectOfType<GameManager>().TransitionToEnd();
        }
    }

    public void AddDeath()
    {
        if (currentHealth == 0)
        {
            DeathData.current.deathCount += 1;
            SaveSystem.SaveDeaths(); // save deaths
        }
    }
    // Collission detection
    void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
        {
           // Debug.Log("HIT Enemy");
            //play collision sound
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            // play death sound and reduce life
            takeDamage(20);
            AddDeath(); // add death count
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
            //play life sound
            FindObjectOfType<AudioManager>().Play("Life");
            increaseLife(10);
        }

        if(other.gameObject.tag == "LevelComplete")
        {
            //Debug.Log("Level Complete");
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
