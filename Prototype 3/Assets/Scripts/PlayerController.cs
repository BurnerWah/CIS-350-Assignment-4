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

    private Animator playerAnimator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    public static PlayerController FindMe() {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start() {
        // Set reference vars to components
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        // start running
        playerAnimator.SetFloat("Speed_f", 1.0f);
        // audio controller
        playerAudio = GetComponent<AudioSource>();
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
            playerAnimator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        // Early short-circuit when game has ended
        if (gameOver) {
            return;
        }
        else if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
            // play dirt particle
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle")) {
            Debug.Log("Game over!");
            gameOver = true;
            // play death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            // play explosion particle
            explosionParticle.Play();
            // stop playing dirt particle
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
