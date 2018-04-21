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
}
