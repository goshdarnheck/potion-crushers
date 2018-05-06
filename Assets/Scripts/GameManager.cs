using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	[SerializeField] float timeLeft = 60f;
	int player1Score = 0;
	int player2Score = 0;

	bool gameOver = false;
	PlayerController playerController;
	PlayerController2 playerController2;
	PotionEmitter potionEmitter;
	EnemyEmitter enemyEmitter;

	ScoreBoard scoreBoard;

	void Start () {
		scoreBoard = FindObjectOfType<ScoreBoard>();
		playerController = FindObjectOfType<PlayerController>();
		playerController2 = FindObjectOfType<PlayerController2>();
		potionEmitter = FindObjectOfType<PotionEmitter>();
		enemyEmitter = FindObjectOfType<EnemyEmitter>();
	}
	
	void Update () {
		float cancelRaw = CrossPlatformInputManager.GetAxisRaw("Cancel");

		if (player1Score != player2Score && gameOver == false) {
			timeLeft -= Time.deltaTime;
		}

		scoreBoard.SetTimerTime(timeLeft);

		if (cancelRaw == 1) {
			SceneManager.LoadScene(0);
		}

		if (timeLeft <= 0) {
			setGameOverState();
		}
	}

	void setGameOverState() {
		gameOver = true;
		playerController.disableControls();
		playerController2.disableControls();
		enemyEmitter.remaining = 0;
		potionEmitter.remaining = 0;

		var enemies = FindObjectsOfType<Enemy>();
		var potions = FindObjectsOfType<Potion>();

		foreach (Enemy enemy in enemies) {
			Destroy(enemy.gameObject);
		}

		foreach (Potion potion in potions) {
			Destroy(potion.gameObject);
		}

		if (player1Score > player2Score) {
			print("player 1 won");
		} else if (player2Score > player1Score) {
			print("player 2 won");
		} else {
			print("no one won????");
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
