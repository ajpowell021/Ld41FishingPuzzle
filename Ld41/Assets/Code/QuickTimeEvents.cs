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
            StartCoroutine(quickTimeOne());
        }
        else if (stateManager.quickTimeDifficulty == 2) {

        }
        else {

        }
    }

    // Private Functions

    private IEnumerator quickTimeOne() {

        uiManager.lightUpRandomKey();
        uiManager.lightUpRandomKey();
        yield return new WaitForSeconds(2);
        uiManager.lightUpRandomKey();
        uiManager.lightUpRandomKey();
        yield return new WaitForSeconds(2);
        uiManager.lightUpRandomKey();
        uiManager.lightUpRandomKey();
    }
}
