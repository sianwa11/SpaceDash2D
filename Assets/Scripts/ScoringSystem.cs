using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public int gems;
    public Text gemText;
    public Text gemsCollected;

    void Start()
    {
        // Change this later
        gemsCollected.text = "Total Gems Collected: " + PlayerPrefs.GetInt("Gems", 0).ToString();   
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.tag == "Gem")
        {
            Destroy(other.gameObject);
            // collect gem
            AddGem();
            // play sound
            FindObjectOfType<AudioManager>().Play("GemCollected");
        }
    }

    void AddGem()
    {
        gems++;
        gemText.text = gems.ToString();

        // save the number of gems
        if (gems > 0)
        {
            PlayerPrefs.SetInt("Gems", gems);
            // congratulate player
        }
        
    }
}
