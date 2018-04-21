using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FishManager : MonoBehaviour {

	// Public Functions

	public IEnumerator moveAllFishes() {
		yield return new WaitForFixedUpdate();
		List<GameObject> fishes = GameObject.FindGameObjectsWithTag("Fish").ToList();

		for (int i = 0; i < fishes.Count; i++) {
			FishMovement fishMovement = fishes[i].GetComponent<FishMovement>();
			fishMovement.moveFish();
		}
	}
}
