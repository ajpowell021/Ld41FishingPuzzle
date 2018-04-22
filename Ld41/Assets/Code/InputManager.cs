using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	// Private State

	private HookMovement hookMovement;
	private PowerBitMovement powerBitMovement;
	private StateManager stateManager;
	private UiManager uiManager;
	private BackToFishingButton backToFishingButton;

	// Init

	private void Start() {
		stateManager = StateManager.Instance;
		hookMovement = GameObject.FindGameObjectWithTag("Hook").GetComponent<HookMovement>();
		powerBitMovement = GameObject.FindGameObjectWithTag("PowerBit").GetComponent<PowerBitMovement>();
		uiManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<UiManager>();
		backToFishingButton = GameObject.Find("NextFishButton").GetComponent<BackToFishingButton>();
	}

	// Update
	private void Update () {
		checkForPowerButton();
		if (stateManager.isMovingLureAround) {
			checkHookMovement();
		}
		checkQuickTimeKeys();
		if (stateManager.onFishStatsScreen) {
			fishCaughtScreen();
		}
	}

	// Hook Movement

	private void checkForPowerButton() {
		if (stateManager.waitingForCast) {
			if (Input.GetKeyDown("space")) {
				powerBitMovement.toggleMoving();
			}
		}
	}

	private void checkHookMovement() {
		if (Input.GetKeyDown("s") || Input.GetKeyDown("down")) {
			hookMovement.moveHook(Vector3.down);
		}
		else if (Input.GetKeyDown("a") || Input.GetKeyDown("left")) {
			hookMovement.moveHook(Vector3.left);
		}
		else if (Input.GetKeyDown("d") || Input.GetKeyDown("right")) {
			hookMovement.moveHook(Vector3.right);
		}
		else if (Input.GetKeyDown("w") || Input.GetKeyDown("up")) {
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

	private void fishCaughtScreen() {
		if (Input.GetKeyDown("return") || Input.GetKeyDown("space")) {
			backToFishingButton.nextLevel();
		}
	}
}
