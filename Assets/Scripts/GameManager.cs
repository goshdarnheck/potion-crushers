using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[SerializeField] float timeLeft = 100f;
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
		return player1Score >= player2Score ? 1 : 2;
	}
}
