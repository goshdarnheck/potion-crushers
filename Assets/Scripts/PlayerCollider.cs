using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    ScoreBoard scoreBoard;

    void Start () {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

	private void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
		scoreBoard.SetPlayer1score(1);
    }
}
