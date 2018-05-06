using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	[SerializeField] float timeLeft = 60f;
	[SerializeField] GameObject winnersCircle;
	int player1Score = 0;
	int player2Score = 0;

	bool gameOver = false;
	int winnerIndex = 0;
	int winnerScale = 120;
	Transform winnerTransform;
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

		if (gameOver) {
			winnerTransform.position = Vector3.MoveTowards(winnerTransform.position, winnersCircle.transform.position, 50 * Time.deltaTime);
			winnerTransform.Rotate(Vector3.up * Time.deltaTime * 90);
			
			if (winnerScale > 0) {
				winnerScale--;
				winnerTransform.localScale = winnerTransform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
			}
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
			winnerIndex = 1;
			winnerTransform = playerController.transform;
			var winnerText = scoreBoard.transform.Find("Winner1");
			winnerText.gameObject.SetActive(true);
		} else if (player2Score > player1Score) {
			print("player 2 won");
			winnerTransform = playerController2.transform;
			winnerIndex = 2;
			var winnerText = scoreBoard.transform.Find("Winner2");
			winnerText.gameObject.SetActive(true);
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
