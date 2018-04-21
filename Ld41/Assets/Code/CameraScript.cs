using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {


	// Public Functions

	public void moveToCatchScreen() {
		transform.position = Vector3.Lerp(transform.position, new Vector3(30, 6, -10), 1);
	}

	public void moveToBoatScreen() {
		transform.position = new Vector3(6, 6, -10);
	}
}
