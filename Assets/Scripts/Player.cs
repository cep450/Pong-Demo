using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public int score { get; private set; }

	[SerializeField] KeyCode keyUp, keyDown;

	[SerializeField] float moveSpeed = 1f;

	[SerializeField] ScoreUI scoreUI;

	public WinScreen winScreen;

	public Paddle paddle;

	[SerializeField] AudioSource audioSource;
	[SerializeField] AudioClip winSound;


    // Update is called once per frame
    void Update()
    {

		// New inputs override old ones- snappier response and aligns with player intent 
		if(Input.GetKeyDown(keyUp)) {
			MoveUpKeyboard();

		} else if(Input.GetKeyDown(keyDown)) {
			MoveDownKeyboard();

		} else if(Input.GetKey(keyUp)) {
			MoveUpKeyboard();

		} else if(Input.GetKey(keyDown)) {
			MoveDownKeyboard();
		}

    }

	// This game only implements the keyboard, so the movement speed is fixed, but this structure also allows us to implement analog controls (like a controller's stick, or a mouse) that move the paddle at different speeds
	void MoveUpKeyboard() {
		paddle.Move(moveSpeed);	
	}
	void MoveDownKeyboard() {
		paddle.Move(-moveSpeed);
	}

	public void AddScore(int amount = 1) {
		SetScore(score + amount);
	}

	public void ResetScore() {
		SetScore(0);
	}

	private void SetScore(int newScore) {
		score = newScore;
		scoreUI.UpdateScore(score);
		if(score >= GameManager.scoreToWin) {
			audioSource.PlayOneShot(winSound);
			GameManager.RegisterWinner(this);
		}
	}
}
