using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

	// When the ball enters this goal, this is the player that will earn a point
	[SerializeField] Player scoringPlayer;
	[SerializeField] int scoreToAdd = 1;

	[SerializeField] AudioSource audioSource;
	[SerializeField] AudioClip soundScore;

	void OnTriggerEnter2D(Collider2D collider) {

		if(collider.CompareTag("Ball")) {
			audioSource.PlayOneShot(soundScore);
			scoringPlayer.AddScore(scoreToAdd);
			if(GameManager.gameInProgress) {
				GameManager.ResetRound();
			}
		}

	}
}
