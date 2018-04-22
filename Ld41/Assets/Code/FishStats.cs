using System.Collections;
using System.Collections.Generic;
using DoodleStudio95;
using UnityEngine;

public class FishStats : MonoBehaviour {

    // Public State

    public float activeFishWeight;
    public FishType activeFishType;
    public float currentScore;

    public Transform weightDisplay;
    public Transform scoreDisplay;
    public Transform guppieType;
    public Transform rainbowType;
    public Transform whaleType;

    private DoodleAnimator guppieAnim;
    private DoodleAnimator rainbowAnim;
    private DoodleAnimator whaleAnim;

    // Private State

    private StateManager stateManager;
    private CameraScript cameraScript;

    // Init

    private void Start() {
        stateManager = StateManager.Instance;
        cameraScript = Camera.main.GetComponent<CameraScript>();
        setAnims();
    }

    // Update

    private void Update() {
        checkForFishCaught();
        updateStatCounters();
        showFishType();
    }

    // Private Functions

    private void setAnims() {
        guppieAnim = guppieType.GetComponent<DoodleAnimator>();
        rainbowAnim = rainbowType.GetComponent<DoodleAnimator>();
        whaleAnim = whaleType.GetComponent<DoodleAnimator>();
    }

    private void checkForFishCaught() {
        if (stateManager.fishCaught) {
            stateManager.onFishStatsScreen = true;
            cameraScript.movetToFishStats();
            stateManager.fishCaught = false;
            calcScore();
        }
    }

    private void updateStatCounters() {
        weightDisplay.GetComponent<DoodleAnimator>().SetFrame(Mathf.RoundToInt(activeFishWeight));
        scoreDisplay.GetComponent<DoodleAnimator>().SetFrame(Mathf.RoundToInt(currentScore));
    }

    private void showFishType() {
        if (activeFishType == FishType.Guppie) {
            guppieAnim.enabled = true;
            rainbowAnim.enabled = false;
            whaleAnim.enabled = false;
        }
        else if (activeFishType == FishType.RainbowFish) {
            guppieAnim.enabled = false;
            rainbowAnim.enabled = true;
            whaleAnim.enabled = false;
        }
        else if (activeFishType == FishType.Whale) {
            guppieAnim.enabled = false;
            rainbowAnim.enabled = false;
            whaleAnim.enabled = true;
        }
    }

    private void calcScore() {
        float timeDiff = stateManager.currentFishStartTime - stateManager.currentFishEndTime;
        int score = 10;

        if (timeDiff < 10) {
            score += 20;
        }
        else if (timeDiff >= 10 && timeDiff < 15) {
            score += 10;
        }

        if (stateManager.quickTimeDifficulty == 1) {
            score += 0;
        }
        else if (stateManager.quickTimeDifficulty == 2) {
            score += 15;
        }
        else if (stateManager.quickTimeDifficulty == 3) {
            score += 20;
        }

        currentScore = score;
        stateManager.totalScore += score;
    }
}
