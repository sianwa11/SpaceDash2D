using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public int gems;
    public Text gemText;
    public Text gemsCollected;
    public Text deathCount;

    private int totalGems;

    void Start()
    {
        // Load deaths and gems on start
        SaveSystem.LoadGame();
        SaveSystem.LoadDeaths();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Trigger");
        if (other.gameObject.tag == "Gem")
        {
            Destroy(other.gameObject);
            // collect gem
            AddGem();
            // play sound
            FindObjectOfType<AudioManager>().Play("GemCollected");
        }
    }
    private void Update()
    {
        // Update UI
        gemsCollected.text = "Total Gems Collected: " + ScoresData.current.gems.ToString();
        deathCount.text = "Deaths: " + DeathData.current.deathCount.ToString();
    }

    void AddGem()
    {
        gems++;
        gemText.text = gems.ToString();
        // store gems and save
        ScoresData.current.gems++;
        SaveSystem.SaveGame();
    }

/*    public void SaveGems()
    {
        SaveSystem.SaveScores(this);
    }

    public void LoadGems()
    {
        ScoresData data = SaveSystem.LoadScores();
        totalGems = data.gems;
    }*/
}
