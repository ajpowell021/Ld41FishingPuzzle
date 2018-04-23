using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgainButton : MonoBehaviour {

	private StateManager stateManager;
	private CameraScript cameraScript;
	private BackToFishingButton backToFishingButton;
	private SpawnLevels spawnLevels;
	private GameObject hook;

	private void Start() {
		stateManager = StateManager.Instance;
		cameraScript = Camera.main.GetComponent<CameraScript>();
		backToFishingButton = GameObject.Find("NextFishButton").GetComponent<BackToFishingButton>();
		spawnLevels = GameObject.FindGameObjectWithTag("Managers").GetComponent<SpawnLevels>();
		hook = GameObject.FindGameObjectWithTag("Hook");
	}

	private void OnMouseDown() {
		stateManager.totalScore = 0;
		stateManager.timer = 60;
		stateManager.onTitleScreen = true;
		stateManager.isMovingLureAround = false;
		cameraScript.moveToTitleScreen();
		spawnLevels.clearLevel();
		backToFishingButton.spawnRandomLevel();
		hook.transform.position = new Vector3(-9, 7, 0);
		stateManager.onFinishScreen = false;
	}
}
