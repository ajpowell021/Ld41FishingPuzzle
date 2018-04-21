using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	// Private State

	private HookMovement hookMovement;
	private PowerBitMovement powerBitMovement;
	private StateManager stateManager;

	// Init

	private void Start() {
		stateManager = StateManager.Instance;
		hookMovement = GameObject.FindGameObjectWithTag("Hook").GetComponent<HookMovement>();
		powerBitMovement = GameObject.FindGameObjectWithTag("PowerBit").GetComponent<PowerBitMovement>();
	}

	// Update
	private void Update () {
		checkForPowerButton();
		checkHookmovement();
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
}
