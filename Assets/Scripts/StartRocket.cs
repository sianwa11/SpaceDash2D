using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRocket : MonoBehaviour
{
    public GameObject player;
    public Sprite rocket;

    private float Delay = 1.0f;

    private void OnTriggerEnter2D()
    {
        Debug.Log("OOOF");
        // change player to rocket
        player.GetComponent<SpriteRenderer>().sprite = rocket;
        player.transform.rotation = Quaternion.Euler(0, 0, 0);

        // disable player1 movement
        Invoke("DisablePlayer", Delay);
        EnableRocket();
    }

    private void DisablePlayer()
    {
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<JumpForce>().enabled = false;
    }

    private void EnableRocket()
    {
        player.GetComponent<RocketMovement>().enabled = true;
    }
}
