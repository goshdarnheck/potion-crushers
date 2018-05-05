using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[SerializeField] float timeLeft = 10f;
	int player1Score = 0;

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

	public int increasePlayer1Score() {
		player1Score++;

		return player1Score;
	}
}
