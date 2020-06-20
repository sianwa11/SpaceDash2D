using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if(enemy.gameObject.tag == "Enemy")
        {
            Debug.Log("Collision Enter");

            // play death sound and reduce life by one

            // restart level if life is not exhausted

            // Game over if lives are exhausted
        }
    }
}
