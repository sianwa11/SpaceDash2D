using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void LevelZero()
    {
        SceneManager.LoadScene("Level0");
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }
}

