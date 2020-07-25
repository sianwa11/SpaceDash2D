using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFalls : MonoBehaviour
{
    private float Delay = 1.0f;
    private void OnTriggerEnter2D()
    {
        Debug.Log("Fallen");
        Invoke("RestartGame", Delay); // wait a second before restart
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart game if player falls
    }
}

