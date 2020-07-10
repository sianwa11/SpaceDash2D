using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void GameOver()
    {
        // transition to game over
        // find a better way to do this later
        SceneManager.LoadScene("GameOver");
    }
}
