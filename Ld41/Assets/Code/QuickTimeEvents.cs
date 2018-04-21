using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTimeEvents : MonoBehaviour {

    // Private State

    private StateManager stateManager;
    private UiManager uiManager;

    // Init

    private void Awake() {
        stateManager = StateManager.Instance;
        uiManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<UiManager>();
    }

    // Update

    private void Update() {
        if (stateManager.inQuickTimeEvent) {
            startQuickTimeEvent();
            stateManager.adjustQuickTimeEvent(false);
        }
    }

    // Public Functions

    public void startQuickTimeEvent() {

        if (stateManager.quickTimeDifficulty == 1) {
            stateManager.setRoundsLeft(5);
            stateManager.setPushedUntilRoundComplete(2);
            stateManager.setTotalPushedPerRound(2);
            displayTwoQuickTimes();
        }
        else if (stateManager.quickTimeDifficulty == 2) {
            stateManager.setRoundsLeft(10);
            stateManager.setPushedUntilRoundComplete(3);
            stateManager.setTotalPushedPerRound(3);
            displayThreeQuickTimes();
        }
        else {
            stateManager.setRoundsLeft(15);
            stateManager.setPushedUntilRoundComplete(4);
            stateManager.setTotalPushedPerRound(4);
            displayFourQuickTimes();
        }
    }

    public void roundCompleted() {
        StopAllCoroutines();
        stateManager.roundComplete();
        if (stateManager.roundsLeft > 0) {
            switch (stateManager.totalPushedPerRound) {
                    case 2:
                        displayTwoQuickTimes();
                        stateManager.setPushedUntilRoundComplete(2);
                        break;
                    case 3:
                        displayThreeQuickTimes();
                        stateManager.setPushedUntilRoundComplete(3);
                        break;
                    case 4:
                        displayFourQuickTimes();
                        stateManager.setPushedUntilRoundComplete(4);
                        break;
            }
        }
    }

    // Private Functions

    private void displayTwoQuickTimes() {
        uiManager.highlightTwoRandomKeys();
    }

    private void displayThreeQuickTimes() {
        uiManager.highlightThreeRandomKeys();
    }

    private void displayFourQuickTimes() {
        uiManager.highlightFourRandomKeys();
    }
}
