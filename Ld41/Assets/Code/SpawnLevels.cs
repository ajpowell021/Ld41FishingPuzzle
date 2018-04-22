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

	private FishStats fishStats;

	private StateManager stateManager;

	private void Awake() {
		stateManager = StateManager.Instance;
		fishStats = GameObject.FindGameObjectWithTag("Managers").GetComponent<FishStats>();
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

		Fish specificFish = fish.GetComponent<Fish>();
		fishStats.activeFishWeight = specificFish.fishWeight;
		fishStats.activeFishType = specificFish.fishType;
		stateManager.quickTimeDifficulty = specificFish.fishDiff;

		GameObject catchingFish = Instantiate(guppie, new Vector3(32, 7, 0), Quaternion.identity).gameObject;
		catchingFish.transform.localScale = new Vector3(1, 2, 1);

		GameObject displayFish = Instantiate(guppie, new Vector3(32, 26, 0), Quaternion.identity).gameObject;
		displayFish.transform.localScale = new Vector3(1, 2, 1);

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

	public void spawnLevelTwo() {

		GameObject fish = Instantiate(rainBowFish, new Vector3(1, 2, 0), Quaternion.identity).gameObject;
		Fish specificFish = fish.GetComponent<Fish>();
		fishStats.activeFishWeight = specificFish.fishWeight;
		fishStats.activeFishType = specificFish.fishType;
		stateManager.quickTimeDifficulty = specificFish.fishDiff;

		GameObject catchingFish = Instantiate(rainBowFish, new Vector3(32, 5.59f, 0), Quaternion.identity).gameObject;
		catchingFish.transform.localScale = new Vector3(1, 2, 1);

		GameObject displayFish = Instantiate(rainBowFish, new Vector3(32, 26, 0), Quaternion.identity).gameObject;
		displayFish.transform.localScale = new Vector3(1, 2, 1);

		Instantiate(log, new Vector3(1, 3, 0), Quaternion.identity);
		Instantiate(log, new Vector3(3, 4, 0), Quaternion.Euler(0, 0, 90));
		Instantiate(log, new Vector3(5, 4, 0), Quaternion.Euler(0, 0, 90));
		Instantiate(log, new Vector3(7, 3, 0), Quaternion.identity);

		GameObject crabOne = Instantiate(crab, new Vector3(4, 3, 0), Quaternion.identity).gameObject;

		FishMovement fishMovement = fish.GetComponent<FishMovement>();
		FishMovement crabMovement = crabOne.GetComponent<FishMovement>();

		fishMovement.fishMoveQueue.Add(Vector3.right);
		fishMovement.fishMoveQueue.Add(Vector3.right);
		fishMovement.fishMoveQueue.Add(Vector3.right);
		fishMovement.fishMoveQueue.Add(Vector3.right);
		fishMovement.fishMoveQueue.Add(Vector3.right);
		fishMovement.fishMoveQueue.Add(Vector3.right);
		fishMovement.fishMoveQueue.Add(Vector3.left);
		fishMovement.fishMoveQueue.Add(Vector3.left);
		fishMovement.fishMoveQueue.Add(Vector3.left);
		fishMovement.fishMoveQueue.Add(Vector3.left);
		fishMovement.fishMoveQueue.Add(Vector3.left);
		fishMovement.fishMoveQueue.Add(Vector3.left);

		crabMovement.fishMoveQueue.Add(Vector3.up);
		crabMovement.fishMoveQueue.Add(Vector3.up);
		crabMovement.fishMoveQueue.Add(Vector3.up);
		crabMovement.fishMoveQueue.Add(Vector3.left);
		crabMovement.fishMoveQueue.Add(Vector3.left);
		crabMovement.fishMoveQueue.Add(Vector3.right);
		crabMovement.fishMoveQueue.Add(Vector3.right);
		crabMovement.fishMoveQueue.Add(Vector3.down);
		crabMovement.fishMoveQueue.Add(Vector3.down);
		crabMovement.fishMoveQueue.Add(Vector3.down);
	}

	public void spawnLevelThree() {

		GameObject fish = Instantiate(whale, new Vector3(10, 5, 0), Quaternion.identity).gameObject;
		Fish specificFish = fish.GetComponent<Fish>();
		fishStats.activeFishWeight = specificFish.fishWeight;
		fishStats.activeFishType = specificFish.fishType;
		stateManager.quickTimeDifficulty = specificFish.fishDiff;

		GameObject catchingFish = Instantiate(whale, new Vector3(32, 7, 0), Quaternion.identity).gameObject;
		catchingFish.transform.localScale = new Vector3(1, 1, 1);

		GameObject displayFish = Instantiate(whale, new Vector3(32, 26, 0), Quaternion.identity).gameObject;
		displayFish.transform.localScale = new Vector3(1, 1, 1);

		Instantiate(log, new Vector3(1, 6, 0), Quaternion.identity);
		Instantiate(log, new Vector3(5, 6, 0), Quaternion.identity);
		Instantiate(log, new Vector3(9, 6, 0), Quaternion.identity);
		Instantiate(log, new Vector3(5, 4, 0), Quaternion.Euler(0, 0, 90));

		FishMovement fishMovement = fish.GetComponent<FishMovement>();

		fishMovement.fishMoveQueue.Add(Vector3.down);
		fishMovement.fishMoveQueue.Add(Vector3.left);
		fishMovement.fishMoveQueue.Add(Vector3.left);
		fishMovement.fishMoveQueue.Add(Vector3.left);
		fishMovement.fishMoveQueue.Add(Vector3.left);
		fishMovement.fishMoveQueue.Add(Vector3.down);
		fishMovement.fishMoveQueue.Add(Vector3.down);
		fishMovement.fishMoveQueue.Add(Vector3.left);
		fishMovement.fishMoveQueue.Add(Vector3.left);
		fishMovement.fishMoveQueue.Add(Vector3.up);
		fishMovement.fishMoveQueue.Add(Vector3.up);
		fishMovement.fishMoveQueue.Add(Vector3.up);
		fishMovement.fishMoveQueue.Add(Vector3.left);
	}
}
