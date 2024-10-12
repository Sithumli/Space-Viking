using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    public float speed; // Set a fixed positive speed, and the object will move left

    private Rigidbody2D myybody;
    private string wall = "wall";

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Fetch the Rigidbody2D component attached to the GameObject
        myybody = GetComponent<Rigidbody2D>();

        // Check if Rigidbody2D component is attached
        if (myybody == null)
        {
            Debug.LogError("Rigidbody2D component is missing from this GameObject.");
        }
    }

    // FixedUpdate is called at fixed time intervals, good for physics-related code
    void FixedUpdate()
    {
        if (myybody != null)
        {
            // Move left by setting the velocity with a negative x value (for left movement)
            myybody.velocity = new Vector2(-speed, myybody.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(wall))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(wall))
            Destroy(gameObject);
    }
}
