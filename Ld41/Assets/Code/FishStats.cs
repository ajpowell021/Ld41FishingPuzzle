using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStats : MonoBehaviour {

    // Private State

    private StateManager stateManager;
    private CameraScript cameraScript;

    // Init

    private void Start() {
        stateManager = StateManager.Instance;
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }

    // Update

    private void Update() {
        checkForFishCaught();
    }

    // Private Functions

    private void checkForFishCaught() {
        if (stateManager.fishCaught) {
            cameraScript.movetToFishStats();
            stateManager.fishCaught = false;
        }
    }
}
