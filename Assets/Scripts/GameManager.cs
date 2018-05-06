using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[SerializeField] float timeLeft = 60f;
	int player1Score = 0;
	int player2Score = 0;

	ScoreBoard scoreBoard;

	void Start () {
		scoreBoard = FindObjectOfType<ScoreBoard>();
	}
	
	void Update () {
		timeLeft -= Time.deltaTime;
		scoreBoard.SetTimerTime(timeLeft);

		if (timeLeft <= 0) {
			SceneManager.LoadScene(0);
		}
	}

	public int updatePlayer1Score(int delta) {
		player1Score += delta;

		return player1Score;
	}

	public int updatePlayer2Score(int delta) {
		player2Score += delta;

		return player2Score;
	}

	public int getWinningPlayer() {
		if (player1Score == player2Score) {
			return 0;
		} else if (player1Score > player2Score) {
			return 1;
		} else {
			return 2;
		}
	}
}
