using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour {

    // Public State

    public Transform powerBar;
    public Transform powerBit;

    // Private State

    private StateManager stateManager;

    // Init

    private void Awake() {
        stateManager = StateManager.Instance;
    }

    // Update

    private void Update() {
        if (!stateManager.waitingForCast) {
            powerBar.GetComponent<SpriteRenderer>().enabled = false;
            powerBit.GetComponent<SpriteRenderer>().enabled = false;
        }
        else {
            powerBar.GetComponent<SpriteRenderer>().enabled = true;
            powerBit.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
