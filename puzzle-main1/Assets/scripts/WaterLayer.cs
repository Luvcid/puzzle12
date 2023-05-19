using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Jika objek yang masuk ke dalam collider memiliki tag "Player"
        if (collision.gameObject.tag == "player")
        {
            // Set layer objek menjadi "Water"
            collision.gameObject.layer = LayerMask.NameToLayer("Water");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Jika objek yang keluar dari collider memiliki tag "Player"
        if (collision.gameObject.tag == "player")
        {
            // Set layer objek menjadi "Default"
            collision.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}