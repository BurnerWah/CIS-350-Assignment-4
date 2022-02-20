/*
 * Jaden Pleasants
 * Assignment 4
 * Repeats the background image
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour {
    Vector3 startPosition;
    float repeatWidth;
    // Start is called before the first frame update
    void Start() {
        // save the starting position of the bg
        startPosition = transform.position;
        // set the repeat width to half of the width of the bg using the boxcollider
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update() {
        // if bg is further to left than repeatwidth, reset to start position
        if (transform.position.x < startPosition.x - repeatWidth) {
            transform.position = startPosition;
        }
    }
}
