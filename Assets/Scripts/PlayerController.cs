using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Floating point variable to store the player's movement speed.
    /// </summary>
    public float speed = 20;

    AudioSource source;

    /// <summary>
    /// Drag for player
    /// </summary>
    public float dragFactor = 0.98f;

    private Rigidbody playerRB;

    // Start is called before the first frame update.
    void Start()
    {
        // Get & store a reference to the Rigidody component so that we an access it.
        playerRB = GetComponent<Rigidbody>();
        // Links audiosource variable to audio source component.
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Walls")
        {
            source.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis ("Horizontal");

        // Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis ("Vertical");

        // Use the two store floats to create a new Vector 3variable movement.
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        playerRB.velocity *= dragFactor;

        // Call the AddForce function of our Rigidbody playerRB supplying movement multiplied by speed to move our player.
        playerRB.AddForce (movement * speed);
    }
}
