using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour {

	private CameraScript cameraScript;
	private StateManager stateManager;


	private void Start() {
		cameraScript = Camera.main.GetComponent<CameraScript>();
		stateManager = StateManager.Instance;
	}

	private void OnMouseDown() {
		cameraScript.moveToTitleScreen();
		stateManager.onRulesPage = false;
	}
}
