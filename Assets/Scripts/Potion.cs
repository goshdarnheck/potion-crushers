using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {
    bool isTouched = false;

    public void touch() {
        isTouched = true;
    }

    public bool hasHadABitOfATouch() {
        return isTouched;
    }
}
