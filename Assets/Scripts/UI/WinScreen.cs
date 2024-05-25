using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{

	[SerializeField] AudioSource audioSource;
	[SerializeField] AudioClip restartSound;

	public void Show() {
		this.gameObject.SetActive(true);
	}

	public void Hide() {
		this.gameObject.SetActive(false);
	}

	public void RestartButtonPressed() {
		audioSource.PlayOneShot(restartSound);
		GameManager.RestartGame();
	}
}
