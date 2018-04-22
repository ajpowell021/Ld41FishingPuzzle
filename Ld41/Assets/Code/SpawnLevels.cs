using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnLevels : MonoBehaviour {

	public Transform guppie;
	public Transform whale;
	public Transform alphaFish;
	public Transform rainBowFish;

	public Transform crab;
	public Transform log;

	private void Start() {
		spawnLevelOne();
	}

	public void clearLevel() {
		List<GameObject> thingsToClear = new List<GameObject>();
		thingsToClear.AddRange(GameObject.FindGameObjectsWithTag("Fish").ToList());
		thingsToClear.AddRange(GameObject.FindGameObjectsWithTag("Crab").ToList());
		thingsToClear.AddRange(GameObject.FindGameObjectsWithTag("Log").ToList());

		for (int i = 0; i < thingsToClear.Count; i++) {
			Destroy(thingsToClear[i]);
		}

		thingsToClear.Clear();
	}

	public void spawnLevelOne() {

		GameObject fish = Instantiate(guppie, new Vector3(6, 5, 0), Quaternion.identity).gameObject;
		Instantiate(log, new Vector3(6, 6, 0), Quaternion.identity);
		Instantiate(log, new Vector3(3, 6, 0), Quaternion.identity);
		Instantiate(log, new Vector3(9, 6, 0), Quaternion.identity);
		GameObject crabOne = Instantiate(crab, new Vector3(3, 7, 0), Quaternion.identity).gameObject;

		FishMovement fishMovement = fish.GetComponent<FishMovement>();
		FishMovement crabMovement = crabOne.GetComponent<FishMovement>();

		fishMovement.fishMoveQueue.Add(Vector3.right);
		fishMovement.fishMoveQueue.Add(Vector3.right);
		fishMovement.fishMoveQueue.Add(Vector3.right);
		fishMovement.fishMoveQueue.Add(Vector3.right);
		fishMovement.fishMoveQueue.Add(Vector3.right);
		fishMovement.fishMoveQueue.Add(Vector3.up);
		fishMovement.fishMoveQueue.Add(Vector3.up);

		crabMovement.fishMoveQueue.Add(Vector3.right);
		crabMovement.fishMoveQueue.Add(Vector3.right);
		crabMovement.fishMoveQueue.Add(Vector3.right);
		crabMovement.fishMoveQueue.Add(Vector3.right);
		crabMovement.fishMoveQueue.Add(Vector3.right);
		crabMovement.fishMoveQueue.Add(Vector3.right);
		crabMovement.fishMoveQueue.Add(Vector3.right);
	}
}
