﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    ScoreBoard scoreBoard;
    GameManager gameManager;

    void Start () {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        gameManager = FindObjectOfType<GameManager>();
    }

	private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Potion") {
            var potion = other.gameObject.GetComponent<Potion>();
            
            if (potion.hasHadABitOfATouch() == false) {
                potion.touch();
                Destroy(other.gameObject);
                scoreBoard.SetPlayer1score(gameManager.increasePlayer1Score());
            }
        }
    }
}
