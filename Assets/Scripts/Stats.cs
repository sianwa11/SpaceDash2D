using UnityEngine;

public class Stats : MonoBehaviour
{
    // come back and review this class!!!!!!
    public ScoringSystem scores;
    public int totalGems;

    // Update is called once per frame
    void Update()
    {
        totalGems = scores.GetGems();
    }
}
