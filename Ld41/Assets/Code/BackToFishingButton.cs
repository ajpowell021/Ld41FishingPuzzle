using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToFishingButton : MonoBehaviour {

	private StateManager stateManager;
	private CameraScript cameraScript;
	private PowerBitMovement powerBitMovement;
	private SpawnLevels spawnLevels;

	private void Start() {
		stateManager = StateManager.Instance;
		spawnLevels = GameObject.FindGameObjectWithTag("Managers").GetComponent<SpawnLevels>();
		cameraScript = Camera.main.GetComponent<CameraScript>();
		powerBitMovement = GameObject.FindGameObjectWithTag("PowerBit").GetComponent<PowerBitMovement>();
	}

	private void OnMouseDown() {
		nextLevel();
	}

	public void nextLevel() {
		cameraScript.moveToBoatScreen();
		stateManager.waitingForCast = true;
		spawnLevels.clearLevel();
		powerBitMovement.toggleMoving();
		spawnRandomLevel();
		stateManager.onFishStatsScreen = false;
	}

	public void spawnRandomLevel() {
		int roll = Random.Range(0, 3);

		switch (roll) {
				case 0:
					spawnLevels.spawnLevelOne();
					break;
				case 1:
					spawnLevels.spawnLevelTwo();
					break;
				case 2:
					spawnLevels.spawnLevelThree();
					break;
		}
	}
}
