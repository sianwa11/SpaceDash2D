using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); 
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // play animation
        transition.SetTrigger("Start");
        // wait
        yield return new WaitForSeconds(transitionTime);
        // if we are in last level load main menu
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            // Load Scene
            SceneManager.LoadScene(levelIndex);
        }
    }
}
