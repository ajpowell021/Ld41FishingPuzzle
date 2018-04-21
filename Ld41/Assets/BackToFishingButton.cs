using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToFishingButton : MonoBehaviour {

	private StateManager stateManager;
	private CameraScript cameraScript;
	private PowerBitMovement powerBitMovement;

	private void Start() {
		stateManager = StateManager.Instance;
		cameraScript = Camera.main.GetComponent<CameraScript>();
		powerBitMovement = GameObject.FindGameObjectWithTag("PowerBit").GetComponent<PowerBitMovement>();
	}

	private void OnMouseDown() {
		cameraScript.moveToBoatScreen();
		stateManager.waitingForCast = true;
		powerBitMovement.toggleMoving();
	}
}
