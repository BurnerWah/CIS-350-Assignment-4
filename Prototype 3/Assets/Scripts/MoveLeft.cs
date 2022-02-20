/*
 * Jaden Pleasants
 * Assignment 4
 * Moves an object left
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {
    public float speed = 30f;
    public float leftBound = -15;

    PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start() {
        playerControllerScript = PlayerController.FindMe();
    }

    // Update is called once per frame
    void Update() {
        if (!playerControllerScript.gameOver) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        // destroy obstacles out of bounds off screen to the left
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
}
