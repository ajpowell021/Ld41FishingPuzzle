using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	// Private State

	private HookMovement hookMovement;
	private PowerBitMovement powerBitMovement;
	private StateManager stateManager;
	private UiManager uiManager;

	// Init

	private void Start() {
		stateManager = StateManager.Instance;
		hookMovement = GameObject.FindGameObjectWithTag("Hook").GetComponent<HookMovement>();
		powerBitMovement = GameObject.FindGameObjectWithTag("PowerBit").GetComponent<PowerBitMovement>();
		uiManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<UiManager>();
	}

	// Update
	private void Update () {
		checkForPowerButton();
		checkHookmovement();
		checkQuickTimeKeys();
	}

	// Hook Movement

	private void checkForPowerButton() {
		if (stateManager.waitingForCast) {
			if (Input.GetKeyDown("space")) {
				powerBitMovement.toggleMoving();
			}
		}
	}

	private void checkHookmovement() {
		if (Input.GetKeyDown("s")) {
			hookMovement.moveHook(Vector3.down);
		}
		else if (Input.GetKeyDown("a")) {
			hookMovement.moveHook(Vector3.left);
		}
		else if (Input.GetKeyDown("d")) {
			hookMovement.moveHook(Vector3.right);
		}
		else if (Input.GetKeyDown("w")) {
			hookMovement.moveHook(Vector3.up);
		}
	}

	private void checkQuickTimeKeys() {
		if (Input.GetKeyDown("up") && stateManager.upArrowLit) {
			uiManager.upArrowClicked();
			stateManager.goodPush();
		}
		else if (Input.GetKeyDown("down") && stateManager.downArrowLit) {
			uiManager.downArrowClicked();
			stateManager.goodPush();
		}
		else if (Input.GetKeyDown("left") && stateManager.leftArrowLit) {
			uiManager.leftArrowClicked();
			stateManager.goodPush();
		}
		else if (Input.GetKeyDown("right") && stateManager.rightArrowLit) {
			uiManager.rightArrowClicked();
			stateManager.goodPush();
		}
		else if (Input.GetKeyDown("space") && stateManager.spacebarLit) {
			uiManager.spaceBarClicked();
			stateManager.goodPush();
		}
	}
}
