using System.Collections;
using System.Collections.Generic;
using DoodleStudio95;
using UnityEngine;

public class FishMovement : MonoBehaviour {

	// Public State

	public List<Vector3> fishMoveQueue;
	public List<Vector3> savedQueue;

	private GameObject hook;
	public bool repeats;

	// Init

	private void Start() {
		hook = GameObject.FindGameObjectWithTag("Hook");
		savedQueue.AddRange(fishMoveQueue);
	}

	// Public Functions

	public void moveFish() {
		if (fishMoveQueue.Count > 0) {
			if (crabHookCheck()) {
				transform.position = Vector3.Lerp(
					transform.position,
					transform.position + fishMoveQueue[0]
					, 1 );

				checkForImageFlip();
				fishMoveQueue.RemoveAt(0);
				checkForRepeat();
			}
		}
	}

	private void checkForRepeat() {
		if (repeats && fishMoveQueue.Count == 0) {
			fishMoveQueue.AddRange(savedQueue);
		}
	}

	private void checkForImageFlip() {
		if (fishMoveQueue[0] == Vector3.left) {
			gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else if (fishMoveQueue[0] == Vector3.right) {
			gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
		}
	}

	public IEnumerator crabDeath() {
		yield return gameObject.GetComponent<DoodleAnimator>().PlayAndPauseAt(0, 8);
		Destroy(gameObject);
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
