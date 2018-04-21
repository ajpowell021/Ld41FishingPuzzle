using System.Collections;
using System.Collections.Generic;
using DoodleStudio95;
using UnityEngine;

public class CatchTextDisplay : MonoBehaviour {

	public List<DoodleAnimationFile> sprites;

	private DoodleAnimator doodleAnimator;
	private StateManager stateManager;
	private QuickTimeEvents quickTimeEvents;

	// Init

	private void Start() {
		doodleAnimator = gameObject.GetComponent<DoodleAnimator>();
		stateManager = StateManager.Instance;
		quickTimeEvents = GameObject.FindGameObjectWithTag("Managers").GetComponent<QuickTimeEvents>();
	}

	// Update

	private void Update() {
		checkForRoundComplete();
	}

	// Public Functions

	private void displayRandomText() {
		int roll = Random.RandomRange(0, sprites.Count);

		doodleAnimator.File = sprites[roll];
		StartCoroutine(stopShowingMessage());
	}

	private IEnumerator stopShowingMessage() {
		yield return new WaitForSeconds(1);
		doodleAnimator.File = null;
	}

	private void checkForRoundComplete() {
		if (stateManager.roundCompleted) {
			displayRandomText();
			stateManager.roundCompleted = false;
			quickTimeEvents.roundCompleted();
		}
	}
}
