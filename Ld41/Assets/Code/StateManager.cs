﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : Singleton<StateManager> {

    protected StateManager() {}

    // Public State

    public bool waitingForCast = true;

    // Public Functions

    public void makeCast(float percentage) {

        // Input Cast Animation If There Is Time!

        GameObject fishHook = GameObject.FindWithTag("Hook");

        Vector3 fishSpawnPosition;

        if (percentage <= 9f) {
            fishSpawnPosition = new Vector3(1, 7, 0);
        }
        else if (percentage > 9f && percentage <= 18f) {
            fishSpawnPosition = new Vector3(2, 7, 0);
        }
        else if (percentage > 18f && percentage <= 27f) {
            fishSpawnPosition = new Vector3(3, 7, 0);
        }
        else if (percentage > 27f && percentage <= 36f) {
            fishSpawnPosition = new Vector3(4, 7, 0);
        }
        else if (percentage > 36f && percentage <= 45f) {
            fishSpawnPosition = new Vector3(5, 7, 0);
        }
        else if (percentage > 45f && percentage <= 54f) {
            fishSpawnPosition = new Vector3(6, 7, 0);
        }
        else if (percentage > 54f && percentage <= 63f) {
            fishSpawnPosition = new Vector3(7, 7, 0);
        }
        else if (percentage > 63f && percentage <= 72f) {
            fishSpawnPosition = new Vector3(8, 7, 0);
        }
        else if (percentage > 72f && percentage <= 81f) {
            fishSpawnPosition = new Vector3(9, 7, 0);
        }
        else if (percentage > 81f && percentage <= 90f) {
            fishSpawnPosition = new Vector3(10, 7, 0);
        }
        else {
            fishSpawnPosition = new Vector3(11, 7, 0);
        }

        fishHook.transform.position = fishSpawnPosition;
        waitingForCast = false;
    }
}
