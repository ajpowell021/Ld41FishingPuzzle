using System.Collections;
using System.Collections.Generic;
using DoodleStudio95;
using UnityEngine;

public class SubmitScoreButton : MonoBehaviour {

	private LeaderBoard leaderBoard;
	private StateManager stateManager;
	private UiManager uiManager;

	private void Start() {
		leaderBoard = GameObject.FindGameObjectWithTag("Managers").GetComponent<LeaderBoard>();
		uiManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<UiManager>();
		stateManager = StateManager.Instance;
	}


	private void OnMouseDown() {
		leaderBoard.AddNewHighScore(uiManager.getNameFromInput(), stateManager.totalScore);
		GameObject.FindGameObjectWithTag("Sent").gameObject.GetComponent<DoodleAnimator>().enabled = true;
		GameObject.FindGameObjectWithTag("Sent").gameObject.GetComponent<BoxCollider>().enabled = true;
	}
}
