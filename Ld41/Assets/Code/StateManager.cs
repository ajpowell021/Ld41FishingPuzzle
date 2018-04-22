using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : Singleton<StateManager> {

    protected StateManager() {}

    // Public State

    public float timer;
    public bool timerRunning;

    public bool waitingForCast = true;

    public bool upArrowLit;
    public bool downArrowLit;
    public bool leftArrowLit;
    public bool rightArrowLit;
    public bool spacebarLit;

    public bool onFishStatsScreen;
    public bool shouldStartQuickTimeEvent;
    public bool isMovingLureAround;
    public int quickTimeDifficulty; // scale 1 to 3
    public int totalPushedPerRound;
    public int pushesUntilRoundComplete;
    public bool roundCompleted;
    public int roundsLeft;

    public bool fishCaught;

    private FishManager fishManager;

    // Init

    private void Start() {
        fishManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<FishManager>();
    }

    // Update

    private void Update() {
        if (timerRunning) {
            timer -= Time.deltaTime;
        }

        if (timer <= 0) {
            timerRunning = false;
        }
    }

    // Public Functions

    public void decreaseTimerForHookMove() {
        --timer;
    }

    public void setQuickTimeDifficulty(int diff) {
        quickTimeDifficulty = diff;
    }

    public void setTotalPushedPerRound(int amount) {
        totalPushedPerRound = amount;
    }

    public void roundComplete() {
        --roundsLeft;
        if (roundsLeft == 0) {
            // FISH CATCH HERE!
            timerRunning = false;
            Debug.Log("FISH HAS BEEN CAUGHT!");
            fishCaught = true;
        }
    }

    public void setRoundsLeft(int amount) {
        roundsLeft = amount;
    }

    public void goodPush() {
        --pushesUntilRoundComplete;

        if (pushesUntilRoundComplete == 0) {
            roundCompleted = true;
        }
    }

    public void setPushedUntilRoundComplete(int amount) {
        pushesUntilRoundComplete = amount;
    }

    public void adjustQuickTimeEvent(bool startQuickTime) {
        shouldStartQuickTimeEvent = startQuickTime;
    }

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

        fishManager.killCrabIfHere(fishSpawnPosition);
        fishHook.transform.position = fishSpawnPosition;
        isMovingLureAround = true;
        waitingForCast = false;
    }
}
