using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum FishType {
	Guppie, //x
	RainbowFish, //x
	Whale,	//x
	BetaFish,
	AlphaFish, //x
	MangalicaFish, //x
	DragonFish,   //
	DogFish,	//
	CatFish,	//
	GiraffeFish
}

public class FishManager : MonoBehaviour {

	// Public Functions

	public IEnumerator moveAllFishes() {
		yield return new WaitForFixedUpdate();
		List<GameObject> fishes = GameObject.FindGameObjectsWithTag("Fish").ToList();
		fishes.AddRange(GameObject.FindGameObjectsWithTag("Crab"));

		for (int i = 0; i < fishes.Count; i++) {
			FishMovement fishMovement = fishes[i].GetComponent<FishMovement>();
			fishMovement.moveFish();
		}
	}

	public void killCrabIfHere(Vector3 position) {
		List<GameObject> crabs = GameObject.FindGameObjectsWithTag("Crab").ToList();

		for (int i = 0; i < crabs.Count; i++) {
			if (crabs[i].transform.position == position) {
				StartCoroutine(crabs[i].GetComponent<FishMovement>().crabDeath());
			}
		}
	}
}
