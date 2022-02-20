/*
 * Jaden Pleasants
 * Assignment 4
 * Manages the game's UI
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public int score = 0;
    public Text scoreText;
    public PlayerController playerControllerScript;
    public bool won = false;
    // Start is called before the first frame update
    void Start() {
        if (scoreText == null) {
            scoreText = FindObjectOfType<Text>();
        }
        if (playerControllerScript == null) {
            playerControllerScript = PlayerController.FindMe();
        }

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update() {
        // display score until game is over
        if (!playerControllerScript.gameOver) {
            scoreText.text = $"Score: {score}";
        }
        // loss condition
        if (playerControllerScript.gameOver && !won) {
            scoreText.text = "You Lose!\nPress R to Try Again!";
        }
        // win condition
        if (score >= 10) {
            playerControllerScript.gameOver = true;
            won = true;
            // playerControllerScript.StopRunning();
            scoreText.text = "You Win!\nPress R to Try Again!";
        }
        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
