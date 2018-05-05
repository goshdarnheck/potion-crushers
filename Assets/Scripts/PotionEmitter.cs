using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEmitter : MonoBehaviour {

    [SerializeField] GameObject potion;
    [SerializeField] public int remaining = 1;
    [SerializeField] float rate = 1f;
    [SerializeField] int scoreValue = 1;
    [SerializeField] float delay = 0f;
	[SerializeField] float range = 35f;

	void Start () {
		StartCoroutine(EmitPotions());
	}
	
    IEnumerator EmitPotions() {
        yield return new WaitForSeconds(delay);

        while (remaining > 0) {
			Vector3 randoSpot = new Vector3(Random.Range(-Mathf.Abs(range), range), 1.2f, Random.Range(-Mathf.Abs(range), range));
            GameObject potionInstance = Instantiate(potion, randoSpot, Quaternion.identity);
            Potion potionThing = potionInstance.GetComponent<Potion>();
            potionThing.scoreValue = scoreValue;

            remaining--;

            yield return new WaitForSeconds(rate);
        }
    }
}