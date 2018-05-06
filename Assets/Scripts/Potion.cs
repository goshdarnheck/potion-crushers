using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {
    public int scoreValue = 1;
    bool isTouched = false;

    public void touch() {
        isTouched = true;
    }

    public bool hasHadABitOfATouch() {
        return isTouched;
    }

    private void OnParticleCollision(GameObject other) {
		if (other.tag == "Magic") {
			print(other);
            Destroy(gameObject);
		}
    }
}
