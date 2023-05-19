using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swim : MonoBehaviour
{
    public float swimSpeed; // Kecepatan berenang karakter
    public float jumpForce; // Kecepatan lompat karakter
    public float Water; // Tinggi air pada area renang
    public float gravity; // Gravitasi yang diterapkan pada karakter ketika berada di dalam air

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Jika karakter berada di dalam air
        if (transform.position.y < Water)
        {
            // Terapkan gravitasi
            rb.AddForce(new Vector2(0, -gravity * rb.mass));

            // Jika tombol lompat ditekan, karakter akan melompat
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, jumpForce * rb.mass));
            }

            // Jika tombol berenang ditekan, karakter akan bergerak maju
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(new Vector2(swimSpeed * rb.mass, 0));
            }
        }
    }
}

