using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayButton : MonoBehaviour {

	private CameraScript cameraScript;
	private StateManager stateManager;


	private void Start() {
		cameraScript = Camera.main.GetComponent<CameraScript>();
		stateManager = StateManager.Instance;
	}

	private void OnMouseDown() {
		cameraScript.moveToRulesScreen();
		stateManager.onRulesPage = true;
	}
}
