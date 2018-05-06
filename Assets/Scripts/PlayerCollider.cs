using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    ScoreBoard scoreBoard;
    GameManager gameManager;

    GameObject potionPickupFX;
    GameObject skullCollideFX;

    void Start () {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        gameManager = FindObjectOfType<GameManager>();
        potionPickupFX = Resources.Load("PotionPickup") as GameObject;
        skullCollideFX = Resources.Load("SkullCollide") as GameObject;
    }

	private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Potion") {
            var potion = other.gameObject.GetComponent<Potion>();
            
            if (potion.hasHadABitOfATouch() == false) {
                potion.touch();
                
                Vector3 thing = new Vector3(0, 5f, 0);
                GameObject fx = Instantiate(potionPickupFX, transform.position + thing, Quaternion.identity);
                fx.transform.parent = transform;
                Destroy(fx, 1f);
                
                Destroy(other.gameObject);
                scoreBoard.SetPlayer1score(gameManager.updatePlayer1Score(1));
            }
        } else if (other.gameObject.tag == "Enemy") {
            Vector3 thing = new Vector3(0, 5f, 0);
            GameObject fx = Instantiate(skullCollideFX, transform.position + thing, Quaternion.identity);
            fx.transform.parent = transform;
            Destroy(fx, 1f);
            
            Destroy(other.gameObject);
            scoreBoard.SetPlayer1score(gameManager.updatePlayer1Score(-1));
        }
    }
}
