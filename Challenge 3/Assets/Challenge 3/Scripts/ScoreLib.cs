/*
 * Jaden Pleasants
 * Assignment 4
 * Manages score system
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreLib : MonoBehaviour {
    public Text scoreBox;

    int score;
    PlayerControllerX pc;

    static ScoreLib _GetNonStaticLib() {
        return GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreLib>();
    }

    public static void AddPoint() {
        _GetNonStaticLib()._AddPoint();
    }
    public static void EndGame() {
        _GetNonStaticLib().DrawEndScreen();
    }

    void _AddPoint() {
        if (!pc.gameOver) {
            if (++score >= 30) {
                DrawEndScreen(true);
            }
            else {
                RedrawScore();
            }
        }
    }

    void RedrawScore() {
        scoreBox.text = $"Score: {score}";
    }

    void DrawEndScreen(bool won = false) {
        pc.gameOver = true;
        scoreBox.text = $"You {(won ? "win" : "lose")}!\nPress R to try again!";
    }

    // Start is called before the first frame update
    void Start() {
        pc = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        score = 0;
        RedrawScore();
    }

    // Update is called once per frame
    void Update() {
        if (pc.gameOver && Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
