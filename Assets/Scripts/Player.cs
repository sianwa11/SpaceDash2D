using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth); // set maxHealth to 100
    }

    void Update()
    {
        // end game if health is 0
        if(currentHealth <= 0)
        {
            FindObjectOfType<GameManager>().TransitionToEnd();
        }
    }
    // Collission detection
    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if(enemy.gameObject.tag == "Enemy")
        {
            Debug.Log("HIT Enemy");

            // play death sound and reduce life
            takeDamage(20);

            // restart level if life is not exhausted

            // Game over if lives are exhausted
        }
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
