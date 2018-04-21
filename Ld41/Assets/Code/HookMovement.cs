using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour {

	// Private State

	private FishManager fishManager;

	// Init

	private void Awake() {
		fishManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<FishManager>();
	}

	// Public Functions

	public void moveHook(Vector3 direction) {
		RaycastHit hit;
		if (!Physics.Raycast(transform.position, direction, out hit, 1)) {
			transform.position = Vector3.Lerp(transform.position, transform.position + direction, 1);
		}

		fishManager.moveAllFishes();
	}
}
