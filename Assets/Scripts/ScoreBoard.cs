using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    [SerializeField] Text player1ScoreText;
    [SerializeField] Text timerText;
    

	void Start() {
        player1ScoreText.text = "0";
	}
	
	public void SetPlayer1score(int score) {
        player1ScoreText.text = score.ToString();
    }

    public void SetTimerTime(int seconds) {
        timerText.text = seconds.ToString();
    }
}
