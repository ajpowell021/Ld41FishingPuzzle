using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	public AudioSource audioSource;
	public List<AudioClip> clips;

	private void Start() {
		audioSource = gameObject.GetComponent<AudioSource>();
	}

	public void playCastSound() {
		audioSource.clip = clips[0];
		audioSource.Play();
	}

	public void playHookMoveSound() {
		audioSource.clip = clips[1];
		audioSource.Play();
	}

	public void playHitNoise() {
		audioSource.clip = clips[2];
		audioSource.Play();
	}
}
