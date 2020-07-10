using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject transitionUI;
    public float endGameDelay = 1f;

    public void TransitionToEnd()
    {
        transitionUI.SetActive(true);
       // Invoke("EndGame", endGameDelay);
    }

    // currently not in use
    public void EndGame()
    {
        Debug.Log("Game Over!");
    }
}
