using System.Collections;
using System.Collections.Generic;
using DoodleStudio95;
using UnityEngine;

public class UiManager : MonoBehaviour {

    // Public State

    public Transform powerBar;
    public Transform powerBit;
    public Transform timerDisplay;

    public Transform upArrow;
    public Transform downArrow;
    public Transform leftArrow;
    public Transform rightArrow;
    public Transform spaceBar;

    // Private State

    private StateManager stateManager;
    private int lastRoll;

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

        udpateTimerCounter();
    }

    // Public Functions

    public void highlightTwoRandomKeys() {
        int roll = Random.Range(1, 11);

        while (roll == lastRoll) {
            roll = Random.RandomRange(1, 11);
        }

        lastRoll = roll;

        switch (roll) {
            case 1:
                StartCoroutine(highlightUpArrow());
                StartCoroutine(highlightDownArrow());
                break;
            case 2:
                StartCoroutine(highlightUpArrow());
                StartCoroutine(highlightLeftArrow());
                break;
            case 3:
                StartCoroutine(highlightUpArrow());
                StartCoroutine(highlightRightArrow());
                break;
            case 4:
                StartCoroutine(highlightLeftArrow());
                StartCoroutine(highlightDownArrow());
                break;
            case 5:
                StartCoroutine(highlightRightArrow());
                StartCoroutine(highlightDownArrow());
                break;
            case 6:
                StartCoroutine(highlightRightArrow());
                StartCoroutine(highlightLeftArrow());
                break;
            case 7:
                StartCoroutine(highlightRightArrow());
                StartCoroutine(highlightSpaceBar());
                break;
            case 8:
                StartCoroutine(highlightLeftArrow());
                StartCoroutine(highlightSpaceBar());
                break;
            case 9:
                StartCoroutine(highlightUpArrow());
                StartCoroutine(highlightSpaceBar());
                break;
            case 10:
                StartCoroutine(highlightDownArrow());
                StartCoroutine(highlightSpaceBar());
                break;
         }
    }

    public void highlightThreeRandomKeys() {
        int roll = Random.Range(1, 11);

        while (roll == lastRoll) {
            roll = Random.RandomRange(1, 11);
        }

        lastRoll = roll;

        switch (roll) {
            case 1:
                StartCoroutine(highlightUpArrow());
                StartCoroutine(highlightDownArrow());
                StartCoroutine(highlightLeftArrow());
                break;
            case 2:
                StartCoroutine(highlightUpArrow());
                StartCoroutine(highlightLeftArrow());
                StartCoroutine(highlightRightArrow());
                break;
            case 3:
                StartCoroutine(highlightDownArrow());
                StartCoroutine(highlightLeftArrow());
                StartCoroutine(highlightRightArrow());
                break;
            case 4:
                StartCoroutine(highlightUpArrow());
                StartCoroutine(highlightDownArrow());
                StartCoroutine(highlightRightArrow());
                break;
            case 5:
                StartCoroutine(highlightUpArrow());
                StartCoroutine(highlightDownArrow());
                StartCoroutine(highlightSpaceBar());
                break;
            case 6:
                StartCoroutine(highlightUpArrow());
                StartCoroutine(highlightLeftArrow());
                StartCoroutine(highlightSpaceBar());
                break;
            case 7:
                StartCoroutine(highlightUpArrow());
                StartCoroutine(highlightRightArrow());
                StartCoroutine(highlightSpaceBar());
                break;
            case 8:
                StartCoroutine(highlightRightArrow());
                StartCoroutine(highlightLeftArrow());
                StartCoroutine(highlightSpaceBar());
                break;
            case 9:
                StartCoroutine(highlightDownArrow());
                StartCoroutine(highlightLeftArrow());
                StartCoroutine(highlightSpaceBar());
                break;
            case 10:
                StartCoroutine(highlightDownArrow());
                StartCoroutine(highlightRightArrow());
                StartCoroutine(highlightSpaceBar());
                break;
        }
    }

    public void highlightFourRandomKeys() {
        int roll = Random.Range(1, 6);

        while (roll == lastRoll) {
            roll = Random.RandomRange(1, 6);
        }

        lastRoll = roll;

        switch (roll) {
            case 1:
                StartCoroutine(highlightUpArrow());
                StartCoroutine(highlightDownArrow());
                StartCoroutine(highlightLeftArrow());
                StartCoroutine(highlightRightArrow());
                break;
            case 2:
                StartCoroutine(highlightUpArrow());
                StartCoroutine(highlightLeftArrow());
                StartCoroutine(highlightRightArrow());
                StartCoroutine(highlightSpaceBar());
                break;
            case 3:
                StartCoroutine(highlightSpaceBar());
                StartCoroutine(highlightDownArrow());
                StartCoroutine(highlightLeftArrow());
                StartCoroutine(highlightRightArrow());
                break;
            case 4:
                StartCoroutine(highlightUpArrow());
                StartCoroutine(highlightDownArrow());
                StartCoroutine(highlightRightArrow());
                StartCoroutine(highlightSpaceBar());
                break;
            case 5:
                StartCoroutine(highlightUpArrow());
                StartCoroutine(highlightDownArrow());
                StartCoroutine(highlightLeftArrow());
                StartCoroutine(highlightSpaceBar());
                break;
        }
    }

    private IEnumerator highlightUpArrow() {
        stateManager.upArrowLit = true;
        yield return upArrow.GetComponent<DoodleAnimator>().PlayAndPauseAt(0, 8);
    }

    private IEnumerator highlightDownArrow() {
        stateManager.downArrowLit = true;
        yield return downArrow.GetComponent<DoodleAnimator>().PlayAndPauseAt(0, 8);
    }

    private IEnumerator highlightLeftArrow() {
        stateManager.leftArrowLit = true;
        yield return leftArrow.GetComponent<DoodleAnimator>().PlayAndPauseAt(0, 8);
    }

    private IEnumerator highlightRightArrow() {
        stateManager.rightArrowLit = true;
        yield return rightArrow.GetComponent<DoodleAnimator>().PlayAndPauseAt(0, 8);
    }

    private IEnumerator highlightSpaceBar() {
        stateManager.spacebarLit = true;
        yield return spaceBar.GetComponent<DoodleAnimator>().PlayAndPauseAt(0, 8);
    }

    public void upArrowClicked() {
        stateManager.upArrowLit = false;
        upArrow.GetComponent<DoodleAnimator>().GoToAndPause();
    }

    public void downArrowClicked() {
        stateManager.downArrowLit = false;
        downArrow.GetComponent<DoodleAnimator>().GoToAndPause();
    }

    public void leftArrowClicked() {
        stateManager.leftArrowLit = false;
        leftArrow.GetComponent<DoodleAnimator>().GoToAndPause();
    }

    public void rightArrowClicked() {
        stateManager.rightArrowLit = false;
        rightArrow.GetComponent<DoodleAnimator>().GoToAndPause();
    }

    public void spaceBarClicked() {
        stateManager.spacebarLit = false;
        spaceBar.GetComponent<DoodleAnimator>().GoToAndPause();
    }

    // Private Funtions

    private void udpateTimerCounter() {
        timerDisplay.GetComponent<DoodleAnimator>().SetFrame(Mathf.RoundToInt(stateManager.timer));
    }
}
