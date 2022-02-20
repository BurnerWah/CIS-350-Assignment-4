/*
 * Jaden Pleasants
 * Assignment 4
 * Controls player movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    public float jumpForce; // my favorite source of onepiece spoilers!
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    public static PlayerController FindMe() {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start() {
        // Set reference vars to components
        rb = GetComponent<Rigidbody>();
        // modify gravity (I think this implementation is weird)
        if (Physics.gravity.y > -10) {
            Physics.gravity *= gravityModifier;
        }
    }

    // Update is called once per frame
    void Update() {
        // I'm intentionally putting !gameOver first so this short-circuits as early as possible
        if (!gameOver && isOnGround && Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        // Early short-circuit when game has ended
        if (gameOver) {
            return;
        }
        else if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle")) {
            Debug.Log("Game over!");
            gameOver = true;
        }
    }
}
