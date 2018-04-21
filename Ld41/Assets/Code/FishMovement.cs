using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {

	// Public State

	public List<Vector3> fishMoveQueue;

	// Public Functions

	public void moveFish() {
		if (fishMoveQueue.Count > 0) {
			transform.position = Vector3.Lerp(
				transform.position,
				transform.position + fishMoveQueue[0]
				,1 );

			fishMoveQueue.RemoveAt(0);
		}
	}
}
