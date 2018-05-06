using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {
    public int scoreValue = 1;
    bool isTouched = false;
    public int hp = 10;

    GameObject potionHitFX;

    void Start() {
        potionHitFX = Resources.Load("PotionHit") as GameObject;
    }

    public void touch() {
        isTouched = true;
    }

    public bool hasHadABitOfATouch() {
        return isTouched;
    }

    private void OnParticleCollision(GameObject other) {
        if (other.tag == "Magic") {
            hp--;

            if (hp <= 0) {
                Vector3 thing = new Vector3(0, -3f, 0);
                GameObject fx = Instantiate(potionHitFX, transform.position + thing, Quaternion.identity);
                Destroy(fx, 1f);
                Destroy(gameObject);
            }
        }
    }
}
