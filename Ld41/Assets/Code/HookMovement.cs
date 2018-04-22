using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour {

	// Private State

	private StateManager stateManager;
	private FishManager fishManager;
	private CameraScript cameraScript;
	private SoundPlayer soundPlayer;

	// Init

	private void Awake() {
		GameObject managers = GameObject.FindGameObjectWithTag("Managers");
		stateManager = StateManager.Instance;
		fishManager = managers.GetComponent<FishManager>();
		cameraScript = Camera.main.GetComponent<CameraScript>();
		soundPlayer = managers.GetComponent<SoundPlayer>();
	}

	// Public Functions

	public void moveHook(Vector3 direction) {
		RaycastHit hit;
		if (!Physics.Raycast(transform.position, direction, out hit, 1)) {
			stateManager.decreaseTimerForHookMove();
			transform.position = Vector3.Lerp(transform.position, transform.position + direction, 1);
			soundPlayer.playHookMoveSound();
			StartCoroutine(fishManager.moveAllFishes());
		}
		else if (hit.collider.CompareTag("Fish")) {
			stateManager.decreaseTimerForHookMove();
			transform.position = Vector3.Lerp(transform.position, transform.position + direction, 1);
			soundPlayer.playHookMoveSound();
			StartCoroutine(fishManager.moveAllFishes());
		}
	}

	private void OnCollisionEnter(Collision other) {
		if (other.transform.CompareTag("Fish")) {
			transitionToFishGame();
		}
	}

	private void transitionToFishGame() {
		stateManager.isMovingLureAround = false;
		cameraScript.moveToCatchScreen();
		transform.position = new Vector3(-10, 7, 0);
		stateManager.adjustQuickTimeEvent(true);
	}
}
