using System.Collections;
using System.Collections.Generic;
using DoodleStudio95;
using UnityEngine;

public class UiManager : MonoBehaviour {

    // Public State

    public Transform powerBar;
    public Transform powerBit;

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
    }

    // Public Functions

    public void lightUpRandomKey() {
        int roll = Random.Range(1, 6);

        while (roll == lastRoll) {
            roll = Random.Range(1, 6);
        }

        lastRoll = roll;

        switch (roll) {
                case 1:
                    StartCoroutine(highlightUpArrow());
                    break;
                case 2:
                    StartCoroutine(highlightDownArrow());
                    break;
                case 3:
                    StartCoroutine(highlightLeftArrow());
                    break;
                case 4:
                    StartCoroutine(highlightRightArrow());
                    break;
                case 5:
                    StartCoroutine(highlightSpaceBar());
                    break;
                default:
                    Debug.Log("roll outta range!");
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
}
