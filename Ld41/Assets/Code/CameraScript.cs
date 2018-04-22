using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {


	private StateManager stateManager;

	// Init

	private void Awake() {
		stateManager = StateManager.Instance;
	}

	// Public Functions

	public void moveToCatchScreen() {
		transform.position = Vector3.Lerp(transform.position, new Vector3(30, 6, -10), 1);
		stateManager.timerRunning = true;
	}

	public void moveToBoatScreen() {
		transform.position = new Vector3(6, 6, -10);
	}

	public void movetToFishStats() {
		transform.position = Vector3.Lerp(transform.position, new Vector3(30, 25, -10), 1);
	}

	public void moveToFinalScreen() {
		transform.position = Vector3.Lerp(transform.position, new Vector3(7, -13, -10), 1);
	}

	public void moveToTitleScreen() {
		transform.position = Vector3.Lerp(transform.position, new Vector3(6, 25, -10), 1);
	}
}
