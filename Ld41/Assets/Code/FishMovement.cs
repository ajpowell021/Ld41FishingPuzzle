using System.Collections;
using System.Collections.Generic;
using DoodleStudio95;
using UnityEngine;

public class FishMovement : MonoBehaviour {

	// Public State

	public List<Vector3> fishMoveQueue;

	private GameObject hook;

	// Init

	private void Start() {
		hook = GameObject.FindGameObjectWithTag("Hook");
	}

	// Public Functions

	public void moveFish() {
		if (fishMoveQueue.Count > 0) {
			if (crabHookCheck()) {
				transform.position = Vector3.Lerp(
					transform.position,
					transform.position + fishMoveQueue[0]
					,1 );

				fishMoveQueue.RemoveAt(0);
			}
		}
	}

	public IEnumerator crabDeath() {
		yield return gameObject.GetComponent<DoodleAnimator>().PlayAndPauseAt(0, 8);
	}

	private bool crabHookCheck() {
		// return true if crab and can move.

		if (gameObject.CompareTag("Crab")) {
			if (hook.transform.position == fishMoveQueue[0] + transform.position) {
				return false;
			}
			return true;
		}
		return true;
	}
}
