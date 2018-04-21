using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour {

	// Public Functions

	public void moveHook(Vector3 direction) {
		RaycastHit hit;
		if (!Physics.Raycast(transform.position, direction, out hit, 1)) {
			transform.position = Vector3.Lerp(transform.position, transform.position + direction, 1);
		}
	}
}
