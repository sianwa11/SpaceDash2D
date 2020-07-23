using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class StartBall : MonoBehaviour
{
    public GameObject player;
    public Sprite ball;

    private float Delay = 1.0f;

    private void OnTriggerEnter2D()
    {
        Debug.Log("OOOF");
        // change player to ball
        player.GetComponent<SpriteRenderer>().sprite = ball;
        player.transform.rotation = Quaternion.Euler(0, 0, 0);

        // disable player2 movement
        Invoke("DisablePlayer", Delay);
        EnableBall();
    }

    private void DisablePlayer()
    {
        player.GetComponent<RocketMovement>().enabled = false;
    }

    private void EnableBall()
    {
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<JumpForce>().enabled = true;
    }
}
