using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBitMovement : MonoBehaviour {

    // Public State

    public float speed;

    // Private State

    private bool movingRight;
    private bool isMoving = true;
    private StateManager stateManager;

    // Init

    private void Awake() {
        stateManager = StateManager.Instance;
    }

    // Update

    private void Update() {
        if (isMoving) {
            moving();
        }
    }

    // Public Functions

    public void toggleMoving() {
        isMoving = !isMoving;

        if (!isMoving) {
            calculatePercentage();
        }
    }

    // Private Functions

    private void calculatePercentage() {
        float stoppedAt = transform.position.x;
        float percentage = (stoppedAt - 2.8f) / 6.5f * 100;
        stateManager.makeCast(percentage);
    }

    private void moving() {
        if (movingRight) {
            transform.Translate (Vector3.right * speed * Time.deltaTime);
        }
        else {
            transform.Translate (Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x >= 9.3 && movingRight) {
            movingRight = false;
        }

        if (transform.position.x <= 2.8 && !movingRight) {
            movingRight = true;
        }
    }
}
