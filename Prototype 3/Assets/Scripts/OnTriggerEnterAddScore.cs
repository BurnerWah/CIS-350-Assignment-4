/*
 * Jaden Pleasants
 * Assignment 4
 * Increases the score when the player enters a trigger
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterAddScore : MonoBehaviour {
    private UIManager uiManager;
    private bool triggered = false;
    // Start is called before the first frame update
    void Start() {
        uiManager = GameObject.FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (!triggered && other.CompareTag("Player")) {
            triggered = true;
            uiManager.score++;
        }
    }
}
