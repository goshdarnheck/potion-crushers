using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] float speed = 5f;
	Transform target;
	PlayerController playerController;
	PlayerController2 playerController2;
	GameManager gameManager;
	public int hp = 2;

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
			Vector3 thing = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.position = Vector3.MoveTowards(transform.position, thing, step);
        }
	}

	void findNewTarget() {
		int winningPlayerIndex = gameManager.getWinningPlayer();
		
		if (winningPlayerIndex == 1) {
			target = playerController.transform;
		} else if (winningPlayerIndex == 2) {
			target = playerController2.transform;
		} else {
			target = null;
		}
	}

	private void OnParticleCollision(GameObject other) {
		if (other.tag == "Magic") {
			hp--;

			if (hp <= 0) {
				Destroy(gameObject);
			}
		}
    }
}
