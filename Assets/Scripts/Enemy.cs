using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] float speed = 5f;
	Transform target;
	PlayerController playerController;
	PlayerController2 playerController2;
	GameManager gameManager;

	// Use this for initialization
	void Start () {
		playerController = FindObjectOfType<PlayerController>();
		playerController2 = FindObjectOfType<PlayerController2>();
		gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;

		findNewTarget();

        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
	}

	void findNewTarget() {
		if (gameManager.getWinningPlayer() == 1) {
			target = playerController.transform;
		} else {
			target = playerController2.transform;
		}
	}
}
