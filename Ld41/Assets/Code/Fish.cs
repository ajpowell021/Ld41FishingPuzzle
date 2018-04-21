using System.Collections;
using System.Collections.Generic;
using DoodleStudio95;
using UnityEngine;



public class Fish : MonoBehaviour {



	public int fishWeight;
	public DoodleAnimator doodleAnimator;
	public FishType fishType;

	// Init

	private void Start() {
		doodleAnimator = gameObject.GetComponent<DoodleAnimator>();
		//fishWeight;
	}


}
