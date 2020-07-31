using UnityEngine;

[System.Serializable]
public class ScoresData
{
    public static ScoresData current = new ScoresData();
    public int gems;

    /*    public ScoresData(ScoringSystem scores)
        {
            gems = scores.gems;
        }*/
}
