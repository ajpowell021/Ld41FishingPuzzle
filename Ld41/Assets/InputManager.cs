using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	// Private State

	private HookMovement hookMovement;

	// Init

	private void Start() {
		hookMovement = GameObject.FindGameObjectWithTag("Hook").GetComponent<HookMovement>();
	}

	// Update
	private void Update () {
		checkHookmovement();
	}

	// Hook Movement

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
