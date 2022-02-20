/*
 * Jaden Pleasants
 * Assignment 4
 * Manages spawning of prefabs
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject obstaclePrefab;
    Vector3 spawnPosition = new Vector3(25, 0, 0);
    float startDelay = 2f;
    float repeatRate = 2f;
    PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start() {
        playerControllerScript = PlayerController.FindMe();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle() {
        if (!playerControllerScript.gameOver) {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
