using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static int scoreToWin = 3;

	public static bool gameInProgress = false;

	[SerializeField] List<Player> players;
	[SerializeField] Ball ball;

	static GameManager Instance;

	void Awake() {
		if(Instance != null && Instance != this) {
			Destroy(this.gameObject);
		} else {
			Instance = this;
		}
	}

    void Start()
    {
        RestartGame();
    }

	// Reset the players' paddles and the ball, but do not reset the score
	public static void ResetRound() {
		foreach(Player player in Instance.players) {
			player.paddle.Recenter();
		}
		Instance.ball.Respawn();
	}

	public static void RegisterWinner(Player winner) {

		if(!gameInProgress) {
			return;
		}

		gameInProgress = false;

		winner.winScreen.Show();
		
	}

	// Restart the game from the beginning
	public static void RestartGame() {
		foreach(Player player in Instance.players) {
			player.ResetScore();
			player.winScreen.Hide();
		}
		ResetRound();
		gameInProgress = true;
	}
}
