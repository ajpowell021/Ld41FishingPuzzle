using System.Collections;
using System.Collections.Generic;
using DoodleStudio95;
using UnityEngine;

public class ScoreController : MonoBehaviour {

	public Transform thousandsDigit;
	public Transform hundredsDigit;
	public Transform tensDigit;
	public Transform onesDigit;

	private DoodleAnimator thousandsAnim;
	private DoodleAnimator hundredsAnim;
	private DoodleAnimator tensAnim;
	private DoodleAnimator onesAnim;

	private StateManager stateManager;

	// Init

	private void Start() {
		stateManager = StateManager.Instance;

		thousandsAnim = thousandsDigit.GetComponent<DoodleAnimator>();
		hundredsAnim = hundredsDigit.GetComponent<DoodleAnimator>();
		tensAnim = tensDigit.GetComponent<DoodleAnimator>();
		onesAnim = onesDigit.GetComponent<DoodleAnimator>();
	}

	private void Update() {
		updateScore();
	}

	private void updateScore() {
		int thousands = stateManager.totalScore / 1000;
		int hundreds = (stateManager.totalScore - thousands * 1000) / 100;
		int tens = (stateManager.totalScore - thousands * 1000 - hundreds * 100) / 10;
		int ones = stateManager.totalScore - thousands * 1000 - hundreds * 100 - tens * 10;

		thousandsAnim.SetFrame(thousands);
		hundredsAnim.SetFrame(hundreds);
		tensAnim.SetFrame(tens);
		onesAnim.SetFrame(ones);
	}
}
