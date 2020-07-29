using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    private int totalGems;

    public int gems;
    public Text gemText;

    void Start()
    {
        gems = 0;
        totalGems = PlayerPrefs.GetInt("TotalGems", totalGems);
    }
    void Update()
    {
        if (gems > totalGems)
        {
            totalGems = gems;
            PlayerPrefs.SetInt("TotalGems", totalGems);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.tag == "Gem")
        {
            Destroy(other.gameObject);
            AddGem();
        }
    }

    void AddGem()
    {
        gems++;
        gemText.text = gems.ToString();
    }

    // come back and review this!!!!!
    public int GetGems()
    {
        int total = PlayerPrefs.GetInt("TotalGems", totalGems);
        return total;
    }
}
